export class EmailTemplates {
  public id: string;
  public emailLabel: string;
  public fromAddress: string;
  public subject: string;
  public templateText: string;
  public emailType: string;
  public bccAddress: string;

  public isDefault: boolean;
  public active: boolean;
  public loadDrafts: boolean;
  public isDraft: boolean;

  public versionCount: number;
  public dateUpdate: string;
  public parentId: string;

}
