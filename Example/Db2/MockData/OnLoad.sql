/* Drop BANK.TABLE CUSTOMER DB2*/
DROP TABLE BANK.CUSTOMER;


/* Create Bank Customer table with 
CustomerId, 
CustomerToAddressId, 
DateOfSingUp, 
TypeOfCustomer, 
DateOfBirth,
FirstName,
LastName,
PhoneNumber,
Email,
Password,
Passport,
NationalId for DB2
ID should be autoincremented and primary key
*/
CREATE TABLE BANK.CUSTOMER
(
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    CUSTOMERTOADDRESSID INT NOT NULL,
    DATEOFSINGUP DATE NOT NULL,
    TYPEOFCUSTOMER VARCHAR(50) NOT NULL,
    DATEOFBIRTH DATE NOT NULL,
    FIRSTNAME VARCHAR(50) NOT NULL,
    LASTNAME VARCHAR(50) NOT NULL,
    PHONENUMBER VARCHAR(50) NOT NULL,
    EMAIL VARCHAR(50) NOT NULL,
    PASSWORD VARCHAR(50) NOT NULL,
    PASSPORT VARCHAR(50) NOT NULL,
    NATIONALID VARCHAR(50) NOT NULL,
    PRIMARY KEY (ID)
);

/* Drop BANK.TABLE ADDRESSES DB2*/
DROP TABLE BANK.ADDRESSES;

/* Create Bank Customer table Addresses for database bank add COUNTRY, CITY, STREET, POSTALCODE, HOUSENUMBER, APARTMENTNUMBER AND EXTRA_INFORMATION*/
CREATE TABLE BANK.ADDRESSES
(
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    COUNTRY VARCHAR(50) NOT NULL,
    CITY VARCHAR(50) NOT NULL,
    STREET VARCHAR(50) NOT NULL,
    POSTALCODE VARCHAR(50) NOT NULL,
    HOUSENUMBER VARCHAR(50) NOT NULL,
    APARTMENTNUMBER VARCHAR(50) NOT NULL,
    EXTRA_INFORMATION VARCHAR(50) NULL,
    PRIMARY KEY (ID)
);



/* DELETE Bank Customer table CustomerToAddressId for DB2*/
DROP TABLE BANK.CUSTOMERTOADDRESSID;

/* Create Bank Customer table CustomerToAddressId for DB2 add foreign keys*/
CREATE TABLE BANK.CUSTOMERTOADDRESSID
(
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    CUSTOMERID INT NOT NULL,
    ADDRESSID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (CUSTOMERID) REFERENCES BANK.CUSTOMER(ID),
    FOREIGN KEY (ADDRESSID) REFERENCES BANK.ADDRESSES(ID)
);

/* Drop BANK.TABLE CURRENCIES DB2*/
DROP TABLE BANK.CURRENCIES;

/* Create Bank Customer table currencies with NAME, CODE, SYMBOL for DB2 add foreign keys*/
CREATE TABLE BANK.CURRENCIES
(
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    NAME VARCHAR(50) NOT NULL,
    CODE VARCHAR(50) NOT NULL,
    SYMBOL VARCHAR(50) NOT NULL,
    PRIMARY KEY (ID)
);

/* DELETE Bank Customer table ACCOUNTS for DB2*/
DROP TABLE BANK.ACCOUNTS;


/* Create Bank Customer table Accounts ID, IBAN (NEEDS TO BE UNIQUE), ACCOUNTTYPEID, BALANCE, CUSTOMERTOACCOUNTID, ISACTIVE, CURRENCYID add foreign keys*/
CREATE TABLE BANK.ACCOUNTS
(
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    IBAN VARCHAR(50) NOT NULL,
    ACCOUNTTYPEID INT NOT NULL,
    BALANCE DECIMAL(10,2) NOT NULL,
    CUSTOMERTOACCOUNTID INT NOT NULL,
    ISACTIVE INT NOT NULL,
    CURRENCYID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (ACCOUNTTYPEID) REFERENCES BANK.ACCOUNTSTYPES(ID),
    FOREIGN KEY (CUSTOMERTOACCOUNTID) REFERENCES BANK.CUSTOMERTOACCOUNTID(ID),
    FOREIGN KEY (CURRENCYID) REFERENCES
    BANK.CURRENCIES(ID)
);


/* Drop BANK.TABLE CURRENCIES DB2*/
DROP TABLE BANK.ACCOUNTSTYPES;

/* Create Bank Customer table AccountsTypes db2*/
CREATE TABLE BANK.ACCOUNTSTYPES
(
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    ACCOUNTTYPE VARCHAR(50) NOT NULL,
    PRIMARY KEY (ID)
);



/* DELETE Bank Customer table CUSTOMERTOACCOUNTID for DB2*/
DROP TABLE BANK.CUSTOMERTOACCOUNTID;

/* Create Bank Customer table CustomerToAccountId db2 ADD FOREIGN KEYS*/

CREATE TABLE BANK.CUSTOMERTOACCOUNTID
(
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    CUSTOMERID INT NOT NULL,
    ACCOUNTID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (CUSTOMERID) REFERENCES BANK.CUSTOMER(ID),
    FOREIGN KEY (ACCOUNTID) REFERENCES BANK.ACCOUNTS(ID)
);


/* DELETE Bank Customer table TRANSACTIONS for DB2*/
DROP TABLE BANK.TRANSACTIONSTYPES;

/* Create Bank Customer table TRANSACTIONSTYPES db2 adding IBAN RELATED AND TRANSACTIONTYPE add foreign keys*/
CREATE TABLE BANK.TRANSACTIONSTYPES
(
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    TRANSACTIONTYPE VARCHAR(50) NOT NULL,
    PRIMARY KEY (ID)
);


/* DELETE Bank Customer table TRANSACTIONS for DB2*/
DROP TABLE BANK.TRANSACTIONS;


/* Create Bank Customer table Transactions db2 adding IBAN RELATED AND TRANSACTIONTYPE add foreign keys ADD DESCRIPTION*/
CREATE TABLE BANK.TRANSACTIONS
(
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    TRANSACTIONTYPEID INT NOT NULL,
    ACCOUNTID INT NOT NULL,
    AMOUNT DECIMAL(18,2) NOT NULL,
    DATEOFTHETRANSACTION DATE NOT NULL,
    DESCRIPTION VARCHAR(50) NOT NULL,
    IBAN VARCHAR(50) NOT NULL,
    IBANRELATED VARCHAR(50) NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (TRANSACTIONTYPEID) REFERENCES BANK.TRANSACTIONSTYPES(ID),
    FOREIGN KEY (ACCOUNTID) REFERENCES BANK.ACCOUNTS(ID)
);



/* Create dummy data for customers  in bank for DB2*/
INSERT INTO BANK.CUSTOMER (CUSTOMERTOADDRESSID, DATEOFSINGUP, TYPEOFCUSTOMER, DATEOFBIRTH, FIRSTNAME, LASTNAME, PHONENUMBER, EMAIL, PASSWORD, PASSPORT, NATIONALID) 
VALUES (1, '2019-01-01', 'Individual', '1990-01-01', 'John', 'Doe', '123456789', 'some@email.com', '123456', '123456', '123456');
INSERT INTO BANK.CUSTOMER (CUSTOMERTOADDRESSID, DATEOFSINGUP, TYPEOFCUSTOMER, DATEOFBIRTH, FIRSTNAME, LASTNAME, PHONENUMBER, EMAIL, PASSWORD, PASSPORT, NATIONALID)
VALUES (2, '2019-01-01', 'Individual', '1990-01-01', 'Jane', 'Doe', '123456789', '', '123456', '123456', '123456');
INSERT INTO BANK.CUSTOMER (CUSTOMERTOADDRESSID, DATEOFSINGUP, TYPEOFCUSTOMER, DATEOFBIRTH, FIRSTNAME, LASTNAME, PHONENUMBER, EMAIL, PASSWORD, PASSPORT, NATIONALID)
VALUES (3, '2019-01-01', 'Individual', '1990-01-01', 'John', 'Smith', '123456789', '', '123456', '123456', '123456');
INSERT INTO BANK.CUSTOMER (CUSTOMERTOADDRESSID, DATEOFSINGUP, TYPEOFCUSTOMER, DATEOFBIRTH, FIRSTNAME, LASTNAME, PHONENUMBER, EMAIL, PASSWORD, PASSPORT, NATIONALID)
VALUES (4, '2019-01-01', 'Individual', '1990-01-01', 'Jane', 'Smith', '123456789', '', '123456', '123456', '123456');
INSERT INTO BANK.CUSTOMER (CUSTOMERTOADDRESSID, DATEOFSINGUP, TYPEOFCUSTOMER, DATEOFBIRTH, FIRSTNAME, LASTNAME, PHONENUMBER, EMAIL, PASSWORD, PASSPORT, NATIONALID)
VALUES (5, '2019-01-01', 'Individual', '1990-01-01', 'John', 'Doe', '123456789', '', '123456', '123456', '123456');
INSERT INTO BANK.CUSTOMER (CUSTOMERTOADDRESSID, DATEOFSINGUP, TYPEOFCUSTOMER, DATEOFBIRTH, FIRSTNAME, LASTNAME, PHONENUMBER, EMAIL, PASSWORD, PASSPORT, NATIONALID)
VALUES (6, '2019-01-01', 'Individual', '1990-01-01', 'Jane', 'Doe', '123456789', '', '123456', '123456', '123456');



/* Create dummy data for addresses for Addresses in bank for DB2*/
INSERT INTO BANK.ADDRESSES (COUNTRY, CITY, STREET, POSTALCODE, HOUSENUMBER, APARTMENTNUMBER)
VALUES ('Bulgaria', 'Sofia', 'Some street', '1000', '1', '1');
INSERT INTO BANK.ADDRESSES (COUNTRY, CITY, STREET, POSTALCODE, HOUSENUMBER, APARTMENTNUMBER)
VALUES ('Bulgaria', 'Sofia', 'Some street', '1000', '1', '2');
INSERT INTO BANK.ADDRESSES (COUNTRY, CITY, STREET, POSTALCODE, HOUSENUMBER, APARTMENTNUMBER)
VALUES ('Bulgaria', 'Sofia', 'Some street', '1000', '1', '3');
INSERT INTO BANK.ADDRESSES (COUNTRY, CITY, STREET, POSTALCODE, HOUSENUMBER, APARTMENTNUMBER)
VALUES ('Bulgaria', 'Sofia', 'Some street', '1000', '1', '4');
INSERT INTO BANK.ADDRESSES (COUNTRY, CITY, STREET, POSTALCODE, HOUSENUMBER, APARTMENTNUMBER)
VALUES ('Bulgaria', 'Sofia', 'Some street', '1000', '1', '5');
INSERT INTO BANK.ADDRESSES (COUNTRY, CITY, STREET, POSTALCODE, HOUSENUMBER, APARTMENTNUMBER)
VALUES ('Bulgaria', 'Sofia', 'Some street', '1000', '1', '6');





/* Create dummy data for CustomerToAddressId in bank for DB2*/
INSERT INTO BANK.CUSTOMERTOADDRESSID (CustomerId, AddressId)
VALUES (1, 1);
INSERT INTO BANK.CUSTOMERTOADDRESSID (CustomerId, AddressId)
VALUES (2, 2);
INSERT INTO BANK.CUSTOMERTOADDRESSID (CustomerId, AddressId)
VALUES (3, 3);
INSERT INTO BANK.CUSTOMERTOADDRESSID (CustomerId, AddressId)
VALUES (4, 4);
INSERT INTO BANK.CUSTOMERTOADDRESSID (CustomerId, AddressId)
VALUES (5, 5);
INSERT INTO BANK.CUSTOMERTOADDRESSID (CustomerId, AddressId)
VALUES (6, 1);

/* Create dummy data for CURRENCIES BASED OF BANK.CURRENCIEs*/
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Bulgarian Lev', 'BGN', 'лв');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Euro', 'EUR', '€');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('US Dollar', 'USD', '$');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('British Pound', 'GBP', '£');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Japanese Yen', 'JPY', '¥');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Swiss Franc', 'CHF', 'Fr');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Canadian Dollar', 'CAD', '$');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Australian Dollar', 'AUD', '$');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Chinese Yuan', 'CNY', '¥');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Swedish Krona', 'SEK', 'kr');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('New Zealand Dollar', 'NZD', '$');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Mexican Peso', 'MXN', '$');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Norwegian Krone', 'NOK', 'kr');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('South African Rand', 'ZAR', 'R');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Russian Ruble', 'RUB', '₽');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Turkish Lira', 'TRY', '₺');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Hong Kong Dollar', 'HKD', '$');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Singapore Dollar', 'SGD', '$');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('Indian Rupee', 'INR', '₹');
INSERT INTO BANK.CURRENCIES (NAME, CODE, SYMBOL)
VALUES ('South Korean Won', 'KRW', '₩');


/*/INSERT INTO BANK.ACCOUNTS (ACCOUNTNUMBER, CUSTOMERTOADDRESSID, CURRENCYID, BALANCE, DATEOFOPENING, DATEOFCLOSING, STATUS)*/

/* Create dummy data for Accounts BASED OF BANK.ACCOUNTS
USING
  ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    IBAN VARCHAR(50) NOT NULL,
    ACCOUNTTYPEID INT NOT NULL,
    BALANCE DECIMAL(10,2) NOT NULL,
    CUSTOMERTOACCOUNTID INT NOT NULL,
    ISACTIVE INT NOT NULL,
    CURRENCYID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (ACCOUNTTYPEID) REFERENCES BANK.ACCOUNTSTYPES(ID),
    FOREIGN KEY (CUSTOMERTOACCOUNTID) REFERENCES BANK.CUSTOMERTOACCOUNTID(ID),
    FOREIGN KEY (CURRENCYID) REFERENCES
    BANK.CURRENCIES(ID)
*/
INSERT INTO BANK.ACCOUNTS (IBAN, ACCOUNTTYPEID, BALANCE, CUSTOMERTOACCOUNTID, ISACTIVE, CURRENCYID)
VALUES ('BG80 BNBG 9661 1020 3456 78', 1, 1000, 1, 1, 1);
INSERT INTO BANK.ACCOUNTS (IBAN, ACCOUNTTYPEID, BALANCE, CUSTOMERTOACCOUNTID, ISACTIVE, CURRENCYID)
VALUES ('BG80 BNBG 9661 1020 3456 79', 1, 1000, 2, 1, 1);
INSERT INTO BANK.ACCOUNTS (IBAN, ACCOUNTTYPEID, BALANCE, CUSTOMERTOACCOUNTID, ISACTIVE, CURRENCYID)
VALUES ('BG80 BNBG 9661 1020 3456 80', 1, 1000, 3, 1, 1);
INSERT INTO BANK.ACCOUNTS (IBAN, ACCOUNTTYPEID, BALANCE, CUSTOMERTOACCOUNTID, ISACTIVE, CURRENCYID)
VALUES ('BG80 BNBG 9661 1020 3456 81', 1, 1000, 4, 1, 1);
INSERT INTO BANK.ACCOUNTS (IBAN, ACCOUNTTYPEID, BALANCE, CUSTOMERTOACCOUNTID, ISACTIVE, CURRENCYID)
VALUES ('BG80 BNBG 9661 1020 3456 82', 1, 1000, 5, 1, 1);
INSERT INTO BANK.ACCOUNTS (IBAN, ACCOUNTTYPEID, BALANCE, CUSTOMERTOACCOUNTID, ISACTIVE, CURRENCYID)
VALUES ('BG80 BNBG 9661 1020 3456 83', 1, 1000, 6, 1, 1);

/* Create dummy data for BANK.CUSTOMERTOACCOUNTID in bank for DB2*/
INSERT INTO BANK.CUSTOMERTOACCOUNTID (CUSTOMERID, ACCOUNTID)
VALUES (1, 1);
INSERT INTO BANK.CUSTOMERTOACCOUNTID (CUSTOMERID, ACCOUNTID)
VALUES (2, 2);
INSERT INTO BANK.CUSTOMERTOACCOUNTID (CUSTOMERID, ACCOUNTID)
VALUES (3, 3);
INSERT INTO BANK.CUSTOMERTOACCOUNTID (CUSTOMERID, ACCOUNTID)
VALUES (4, 4);
INSERT INTO BANK.CUSTOMERTOACCOUNTID (CUSTOMERID, ACCOUNTID)
VALUES (5, 5);
INSERT INTO BANK.CUSTOMERTOACCOUNTID (CUSTOMERID, ACCOUNTID)
VALUES (6, 6);









/* Create dummy data for AccountsTypes without ID using ACCOUNTTYPE*/
INSERT INTO BANK.ACCOUNTSTYPES (ACCOUNTTYPE)
VALUES ('Current');
INSERT INTO BANK.ACCOUNTSTYPES (ACCOUNTTYPE)
VALUES ('Savings');
INSERT INTO BANK.ACCOUNTSTYPES (ACCOUNTTYPE)
VALUES ('Credit');
INSERT INTO BANK.ACCOUNTSTYPES (ACCOUNTTYPE)
VALUES ('Debit');
INSERT INTO BANK.ACCOUNTSTYPES (ACCOUNTTYPE)
VALUES ('Loan');
INSERT INTO BANK.ACCOUNTSTYPES (ACCOUNTTYPE)
VALUES ('Mortgage');




/* Create dummy data for BANK.TRANSACTIONSTYPES in bank for DB2*/
INSERT INTO BANK.TRANSACTIONSTYPES (TRANSACTIONTYPE)
VALUES ('Deposit');
INSERT INTO BANK.TRANSACTIONSTYPES (TRANSACTIONTYPE)
VALUES ('Withdraw');
INSERT INTO BANK.TRANSACTIONSTYPES (TRANSACTIONTYPE)
VALUES ('Transfer');



/* Create dummy data for BANK.TRANSACTIONS in bank for DB2
using
    ID INT NOT NULL GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1),
    TRANSACTIONTYPEID INT NOT NULL,
    ACCOUNTID INT NOT NULL,
    AMOUNT DECIMAL(18,2) NOT NULL,
    DATEOFTHETRANSACTION DATE NOT NULL,
    DESCRIPTION VARCHAR(50) NOT NULL,
    IBAN VARCHAR(50) NOT NULL,
    IBANRELATED VARCHAR(50) NOT NULL,
*/
INSERT INTO BANK.TRANSACTIONS (TRANSACTIONTYPEID, ACCOUNTID, AMOUNT, DATEOFTHETRANSACTION, DESCRIPTION, IBAN, IBANRELATED)
VALUES (1, 1, 1000, '2019-01-01', 1, 'BG80 BNBG 9661 1020 3456 78', 'BG80 BNBG 9661 1020 3456 78');
INSERT INTO BANK.TRANSACTIONS (TRANSACTIONTYPEID, ACCOUNTID, AMOUNT, DATEOFTHETRANSACTION, DESCRIPTION, IBAN, IBANRELATED)
VALUES (2, 1, 1000, '2019-01-01', 2, 'BG80 BNBG 9661 1020 3456 78', 'BG80 BNBG 9661 1020 3456 78');
INSERT INTO BANK.TRANSACTIONS (TRANSACTIONTYPEID, ACCOUNTID, AMOUNT, DATEOFTHETRANSACTION, DESCRIPTION, IBAN, IBANRELATED)
VALUES (3, 1, 1000, '2019-01-01', 3, 'BG80 BNBG 9661 1020 3456 78', 'BG80 BNBG 9661 1020 3456 78');
INSERT INTO BANK.TRANSACTIONS (TRANSACTIONTYPEID, ACCOUNTID, AMOUNT, DATEOFTHETRANSACTION, DESCRIPTION, IBAN, IBANRELATED)
VALUES (1, 2, 1000, '2019-01-01',1, 'BG80 BNBG 9661 1020 3456 79', 'BG80 BNBG 9661 1020 3456 79');
INSERT INTO BANK.TRANSACTIONS (TRANSACTIONTYPEID, ACCOUNTID, AMOUNT, DATEOFTHETRANSACTION, DESCRIPTION, IBAN, IBANRELATED)
VALUES (2, 2, 1000, '2019-01-01',3, 'BG80 BNBG 9661 1020 3456 79', 'BG80 BNBG 9661 1020 3456 79');
INSERT INTO BANK.TRANSACTIONS (TRANSACTIONTYPEID, ACCOUNTID, AMOUNT, DATEOFTHETRANSACTION, DESCRIPTION, IBAN, IBANRELATED)
VALUES (3, 2, 1000, '2019-01-01', 2, 'BG80 BNBG 9661 1020 3456 79', 'BG80 BNBG 9661 1020 3456 79');
INSERT INTO BANK.TRANSACTIONS (TRANSACTIONTYPEID, ACCOUNTID, AMOUNT, DATEOFTHETRANSACTION, DESCRIPTION, IBAN, IBANRELATED)
VALUES (1, 3, 1000, '2019-01-01', 1, 'BG80 BNBG 9661 1020 3456 80', 'BG80 BNBG 9661 1020 3456 80');















/* Create all tables needed for a functioning bank*/
/*CREATE TABLE BANK
(
    ACCOUNT_NUMBER INT NOT NULL,
    ACCOUNT_TYPE VARCHAR(20) NOT NULL,
    ACCOUNT_BALANCE INT NOT NULL,
    ACCOUNT_STATUS VARCHAR(20) NOT NULL,
    ACCOUNT_OWNER VARCHAR(20) NOT NULL,
    ACCOUNT_PIN INT NOT NULL,
    ACCOUNT_SSN INT NOT NULL,
    ACCOUNT_ADDRESS VARCHAR(20) NOT NULL,
    ACCOUNT_CITY VARCHAR(20) NOT NULL,
    ACCOUNT_STATE VARCHAR(20) NOT NULL,
    ACCOUNT_ZIP INT NOT NULL,
    ACCOUNT_PHONE INT NOT NULL,
    ACCOUNT_EMAIL VARCHAR(20) NOT NULL,
    ACCOUNT_DOB DATE NOT NULL,
    ACCOUNT_JOINDATE DATE NOT NULL,
    ACCOUNT_LASTLOGIN DATE NOT NULL,
    ACCOUNT_LASTLOGOUT DATE NOT NULL,
    ACCOUNT_LASTTRANSACTION DATE NOT NULL,
    ACCOUNT_LASTTRANSACTIONAMOUNT INT NOT NULL,
    ACCOUNT_LASTTRANSACTIONTYPE VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROM VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONTO VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNT INT NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNT INT NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNTTYPE VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNTTYPE VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNTBALANCE INT NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNTBALANCE INT NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNTSTATUS VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNTSTATUS VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNTOWNER VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNTOWNER VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNTPIN INT NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNTPIN INT NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNTSSN INT NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNTSSN INT NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNTADDRESS VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNTADDRESS VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNTCITY VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNTCITY VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROMACCOUNTSTATE VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONTOACCOUNTSTATE VARCHAR(20) NOT NULL,
    ACCOUNT_LASTTRANSACTIONFROM
*/