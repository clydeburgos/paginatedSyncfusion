import { Component, OnInit } from '@angular/core';
import { DataStateChangeEventArgs, GridComponent, GridModel } from '@syncfusion/ej2-angular-grids';
import { BehaviorSubject } from 'rxjs';
import { EmailTemplates } from 'src/app/models/email-templates';
import { EmailTemplatesService } from 'src/app/services/email-templates.service';

@Component({
  selector: 'app-email-templates-list',
  templateUrl: './email-templates-list.component.html',
  styleUrls: ['./email-templates-list.component.css']
})
export class EmailTemplatesListComponent implements OnInit {

  public dateFormat: any = { type:"date", format:"yyyy-MM-dd" };
  public emailTemplatesData: BehaviorSubject<EmailTemplates[]>;
  public emailTemplateChildData: any[];
  public filterOptions: any;
  public pageOptions: object;
  public state : DataStateChangeEventArgs;
  public pagedData: boolean = true;

  public selectedIndex: number = 0;
  public searchKeyword: string = '';
  public orderBy: string = 'emailLabel';
  public sortDir: string = 'ascending';

  public childGrid: GridModel | GridComponent = {
    queryString: 'parentId',
    columns: [
        { field: 'emailLabel', headerText: 'Email'},
        { field: 'fromAddress', headerText: 'From Email'},
        { field: 'dateUpdated', headerText: 'Date Updated', format: this.dateFormat, type: 'date'}
    ],
    load() {
        const parentId = 'parentId';
        (this as GridComponent).parentDetails.parentKeyFieldValue = (<{ parentId?: string}>(this as GridComponent).parentDetails.parentRowData)[parentId];
    }
};
  constructor(private emailTemplatesService: EmailTemplatesService) {
    this.emailTemplatesData = new BehaviorSubject(null);

  }

  ngOnInit() {
    this.pageOptions = { pageSize: 10 };
    this.state = { skip: 0, take: 10, search: [], sorted: [] };
    this.filterOptions = {
      type: 'Menu'
    };

    this.getEmailTemplates();
  }

  onselected(e){
    this.selectedIndex = e.selectedIndex;
    this.getEmailTemplates();
  }

  dataStateChange(state : DataStateChangeEventArgs){
    this.state = state;
    console.log(state)
    this.getEmailTemplates();
  }

  search(){
    this.getEmailTemplates(true);
  }

  getEmailTemplates(searched: boolean = false){
    this.emailTemplateChildData = [];
    let service = null;

    this.handleServerSorting();
    service = this.emailTemplatesService.getPaged(this.state.skip, this.state.take, searched ? this.searchKeyword : '',
    this.orderBy, this.sortDir);


    service.subscribe((res : any) => {
      this.emailTemplatesData.next(res);
      this.handleChildData(res);
    }, (error: any) => {
      //toast
    }, () => {
    });
  }

  rowDataBound(args){
    args.data.dateUpdate = new Date(args.data.dateUpdate);
  }

  private handleChildData(res: any) {
      //@TODO : Probably not a good idea since it hijacks
      //existing data but the browser should be able to handle a not so many records
      res.result.forEach(item => {
        if(item.versions && item.versions.length > 0) {
          item.versions.forEach(element => {
            this.emailTemplateChildData.push(element);
          });
        }
      });
      this.childGrid.dataSource = this.emailTemplateChildData;
  }

  private handleServerSorting(){
    let sortedData = (this.state.sorted && this.state.sorted.length) > 0 ? this.state.sorted[0] : null;
    if(sortedData) {
      this.orderBy = sortedData.name;
      this.sortDir = sortedData.direction;
    }
  }
}
