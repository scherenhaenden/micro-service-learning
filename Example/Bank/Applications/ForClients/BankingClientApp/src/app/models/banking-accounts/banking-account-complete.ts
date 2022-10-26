import { BankingAccountSimple } from "./banking-account-simple";
import { BankingTransaction } from "./banking-transaction";

export class BankingAccountComplete extends BankingAccountSimple{
  public accountNumber!: string;
  public transactions!: BankingTransaction[];
}
