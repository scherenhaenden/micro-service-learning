export class BankingTransaction {
  public id!: string;
  public date!: Date;
  public description!: string;
  public amount!: number;
  public currency!: string;
  public type!: string;
  public isBlocked!: boolean;
  public relatedTransactionAccountNumber!: string;
}
