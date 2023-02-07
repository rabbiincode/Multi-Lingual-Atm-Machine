using ShegeBank.Enum;

namespace ShegeBank.LanguageChoice;

internal partial class Languages
{
    public static string[,] language = new string[3, 91]
    {
        //English Language
        {
            //Utility.cs
            "Press Enter to Continue",
            "Invalid pin...enter your 4 digit pin",
            "Pin not in correct format...enter your 4 digit number",

            //Validate.cs
            "Invalid Input...try again", //--3

            //Atm.cs/ValidateCardNumberAndPassword
            "Enter your pin",
            "Please wait", //--5
            "Incorrect pin...please try again",
            "Your account will be locked on the third wrong attempt",

            //Atm.cs/CheckBalance
            "Account balance",

            //Atm.cs/ValidateDeposit
            "Deposit must be made in multiples of 500 and 1000 only",
            "Enter the amount you want to deposit",
            "Please ensure that cash loaded into the machine are ONLY in multiple of 500 and 1000 \nas the atm cannot dispense back non-multiples once loaded and will not validate them",
            "Please load your cash in the atm's cash collector",
            "Validating cash...please wait",
            "Counting cash",
            "Deposit Summary",
            "Total",
            "Your deposit of",
            "was successful",

            //Atm.cs/ValidateWithdrawal
            "Enter option", //--19
            "Invalid input...please select any option", //--20

            //Atm.cs/OptionWithdrawal
            "Insufficient fund", //-- 21

            //Atm.cs/OtherWithdrawal
            "Enter the amount you want to withdraw",
            "Amount must be greater than 0", //--23
            "Amount must be in multiples of 500 and 1000",
            "Cannot withdraw more than",

            //Atm.cs/WithdrawalMessage
            "Please Note - The atm does not take back cash after despensing",
            "Your withdrawal of",
            "was successful",
            "Please take your cash",

            //Atm1.cs/ValidateTransfer
            "Enter the amount you want to transfer",
            "Enter the account number you want to transfer to",
            "Account number invalid...please input a valid account number",
            "Cannot transfer to your account...please input a valid account number",
            "Please wait while your transaction is processing",
            "Transfer",
            "to",
            "Enter 1 to continue and 2 to terminate", //--37
            "Transfer of",
            "to",
            "was successful",

            //Atm1.cs/MobileNumberChoice
            "Enter the mobile number you want to recharge",

            //Atm1.cs/OtherAirtime
            "Enter the amount you want to recharge",
            "You cannot recharge more than",
            "at a time",

            //Atm1.cs/RechargeMessage
            "Recharge mobile no",
            "with",
            "Mobile no",
            "has been recharged with",
            "successfully",

            //Atm[Atm1].cs/InsertTransaction --(1)
            "Cash deposit at shege bank atm",
            "Cash withdrawal at shege bank atm",
            "Cash transfer to",
            "Cash transfer from",
            "at shege bank atm",
            "Airtime top-up at shege bank atm",

            //Atm1.cs/ViewTransaction
            "Id",
            "Transaction Date",
            "Type",
            "Amount",
            "Description",
            "No of transaction(s)",
            "You have no transaction(s) yet",

            //Option.cs
            "Enter any option to continue",

            //Pick.cs
            "Do you want to perform another transaction?",
            "Enter 1 if yes or 2 if no",
            "Have a nice day",
            "Please take your card",

            //UserScreen.cs/LockAccount
            "\nMaximum pin trial exceeded",
            "For security purposes, your Account has been suspended... visit our nearest branch for futher information and actions",
            "\nYour Card has been withheld",

            //UserScreen.cs/AtmMenu
            "What do you want to do?",
            "Account Balance",
            "Cash Deposit",
            "Withdrawal",
            "Transfer",
            "Airtime",
            "Transaction History",
            "Cancel",
            "Select number",

            //UserScreen.cs/WithdrawalOption
            "How much do you want to withdraw?",
            "Other Amounts", //--81
            "Select option", //--82

            //UserScreen.cs/AirtimeOption
            "How much do you want to recharge?",

            //UserScreen.cs/RechargeChoice
            "Who do you want to recharge for?",
            "Self",
            "Others",

            //Atm[Atm1].cs/InsertTransaction --(2)
            "Deposit", //--87
            "Withdrawal",
            "Transfer",
            "Airtime"
        },

        //Broken English Language
        {
            //Utility.cs
            "Press Enter if you wan continue",
            "Pin no dey valid...put ya 4 digit pin number",
            "Pin no dey in correct format...put ya 4 digit pin",

            //Validate.cs
            "Wetin you enter no valid...try am again",

            //Atm.cs/ValidateCardNumberAndPassword
            "Put ya pin",
            "Abeg wait",
            "Pin no dey correct...abeg try again",
            "We go lock ya account after you don put pin wey no correct 3 times",

            //Atm.cs/CheckBalance
            "Moni wey remain for account",

            //Atm.cs/ValidateDeposit
            "Moni wey you go put for ATM must dey for 500 and 1000 only",
            "How much moni you wan put for your account",
            "Make sure say the moni wey you put for ATM dey only for 500 and 1000 because \nATM no fit give you back moni wey no dey for 500 and 1000 if you put am inside",
            "Abeg put your moni for inside wetin atm dey use collect cash",
            "We dey Validate your moni...abeg wait",
            "Counting moni",
            "Summary of moni wey you put",
            "Total moni",
            "The Moni wey you put wey be",
            "dey successful",

            //Atm.cs/ValidateWithdrawal
            "Enter ya choice",
            "Input no dey valid...please pick any option",

            //Atm.cs/OptionWithdrawal
            "Moni no reach",

            //Atm.cs/OtherWithdrawal
            "Put the amount you wan collect",
            "Amount wey you put must pass 0",
            "Amount wey you go put must dey for 500 and 1000 only",
            "You no fit collect pass",

            //Atm.cs/WithdrawalMessage
            "Note - Atm no dey take back moni after e don give am out",
            "The Moni wey you collect",
            "dey successful",
            "Abeg take your moni",

            //Atm1.cs/ValidateTransfer
            "Put the amount you wan transfer",
            "Put the account number you wan transfer to",
            "Account number no valid...abeg put valid account number",
            "You no fit transfer moni go your account...abeg put valid account number",
            "Abeg wait, we dey process your transaction",
            "Send moni",
            "give",
            "Put 1 if you wan continue and 2 to stop am",
            "Transfer of",
            "to",
            "dey successful",

            //Atm1.cs/MobileNumberChoice
            "Put the phone number you wan load card for",

            //Atm1.cs/OtherAirtime
            "Put the amount you wan load for phone",
            "You no fit load pass",
            "for on go",

            //Atm1.cs/RechargeMessage
            "Load phone no",
            "with",
            "Phone no",
            "don dey loaded with",
            "successfully",

            //Atm[Atm1].cs/InsertTransaction --(1)
            "Moni wey i put for shege bank atm",
            "Moni wey i collect for shege bank atm",
            "Moni wey i transfer to",
            "Moni transfer from",
            "for shege bank atm",
            "Phone recharge for shege bank atm",

            //Atm1.cs/ViewTransaction
            "Id",
            "Date wey you do transaction",
            "Type",
            "Moni",
            "Description",
            "No of transaction(s) wey you don do",
            "You never do any transaction(s) yet",

            //Option.cs
            "Enter any option if you wan continue",

            //Pick.cs
            "You wan do any other thing?",
            "Press 1 if na yes or 2 if na no",
            "Make your day go wella",
            "Abeg collect ya card",

            //UserScreen.cs/LockAccount
            "\nTime wey we give you make you put ya correct pin don finish",
            "Because we wan secure ya account, we don lock am... go we closest office make we for open am",
            "\nWe don collect ya Card",

            //UserScreen.cs/AtmMenu
            "Wetin you wan do?",
            "Moni wey remain for account",
            "Put Moni",
            "Collect Moni",
            "Send Moni",
            "Load Card",
            "Transaction wey you don do",
            "Cancel",
            "Choose number",

            //UserScreen.cs/WithdrawalOption
            "How much you wan collect?",
            "Another Moni",
            "Select wetin you want",

            //UserScreen.cs/AirtimeOption
            "How much you wan put for phone?",

            //UserScreen.cs/RechargeChoice
            "Who you wan put moni for phone for?",
            "Myself",
            "Person",

            //Atm[Atm1].cs/InsertTransaction --(2)
            "Put Moni",
            "Commot Moni",
            "Send Moni",
            "Load Card"
        },

        //Igbo Language
        {
            //Utility.cs
            "Pia Enter obuna ichoro e ga n'iru",
            "Onuogugu nzuzo gi ezughi ezu...tinye onuogugu nzuzo ano gi",
            "Onuogugu nzuzo gi adiro otu o kwesiri di...tinye onuogugu nzuzo ano gi",

            //Validate.cs
            "Ihe e tinye adiro otu o kwesiri di...tinye ozo",

            //Atm.cs/ValidateCardNumberAndPassword
            "Tinye onuogugu nzuzo gi",
            "Nwee ndidi",
            "Onuogugu nzuzo gi abanyeghi...tinye ya ozo",
            "A ga apochi acconti gi ma itenye Onuogugu nzuzo gi na abanyeghi mboro ato",

            //Atm.cs/CheckBalance
            "Ego foduru na accounti gi",

            //Atm.cs/ValidateDeposit
            "Ego e ga etinye n'ime ATM ga adi na naani notii 500 na 1000",
            "Pinye ego ichoro itenye na accounti gi",
            "Biko tinye naani ego gbara na 500 na 1000 n'ime ATM maka na ATM eweghi ike \ne nyeachi gi ego n'agbara na 500 na 1000 ma itenye ya",
            "Biko tinye ego gi n'ime ihe atm ji anata ego",
            "Ka anyi nnene ego gi...biko nwee ndidi",
            "Anyi na agu ego gi",
            "Ego iteneyere",
            "Mgbako Ego itenyere",
            "Ego e tinyere",
            "banyere",

            //Atm.cs/ValidateWithdrawal
            "Tineye nke e horo",
            "Ihe e tinyere abanyeghi...bike horo nke obuna",

            //Atm.cs/OptionWithdrawal
            "Ego foduro na accounti gi, eruro nke e i choro ewere",

            //Atm.cs/OtherWithdrawal
            "Tinye ego i choro ewere",
            "Ego e tinyere ga agafe 0",
            "Ego e ga etinye ga adi na naani notii 500 na 1000",
            "E ma were karia",

            //Atm.cs/WithdrawalMessage
            "Atm adighi ewere ego oburu na ego aputa go",
            "Ego e were",
            "banyere",
            "Biko were ego gi",

            //Atm1.cs/ValidateTransfer
            "Tinye ego e choro i zigara mmadu",
            "Tinye accounti number e choro i zigara ego",
            "Accounti number e tinyere abanyeghi...biko tinye nke ga abanye",
            "E m'zigawu ego na accounti gi...biko tinye nke ga abanye",
            "Biko nwee ndidi ka anyi chikota ihe e tinyere",
            "Zigara",
            "nye",
            "Tinye 1 e ga n'iru na 2 e kwusi ya",
            "Ego e zigara",
            "nye",
            "banyere",

            //Atm1.cs/MobileNumberChoice
            "Tinye akara ekwenti e choro i tinye card na",

            //Atm1.cs/OtherAirtime
            "Tinye ego e choro etinye n'akara ekwenti gi",
            "E gahi etinye karia",
            "n'otu mgboro",

            //Atm1.cs/RechargeMessage
            "Tinye ego n'akara ekwenti",
            "jiri",
            "Akara ekwenti",
            "e tinyere",
            "banyere",

            //Atm[Atm1].cs/InsertTransaction --(1)
            "Ego m'tinyere na shege bank atm",
            "Ego m'were na shege bank atm",
            "Ego m'zigara",
            "Ego e zigara m site na",
            "na shege bank atm",
            "Ego m'tinyere na akara ekwenti na shege bank atm",

            //Atm1.cs/ViewTransaction
            "Onuogugu",
            "Ubochi",
            "Ihe e'mere",
            "Ego",
            "Edemede",
            "Onuogugu ole e megoro",
            "E mebedhi ihe obuna gbasara ego",

            //Option.cs
            "Pinye nke e horo m'icho iga n'ihu",

            //Pick.cs
            "E choro ime ihe obula ozo?",
            "Pia 1 obuna e choro ime ihe ozo m'obu 2 obuna onweghi ihe ozo",
            "Ubochi gi ga nke oma",
            "Biko were card gi",

            //UserScreen.cs/LockAccount
            "\nOge anyi nyere gi etinye onuogugu nzuzo gi agafela",
            "Maka ichikota accounti gi, anyi akpochigo ya... ga ulo oru anyi ebe ka gi nso ka anyi kponye ya",
            "\nAnyi egidego card gi",

            //UserScreen.cs/AtmMenu
            "Kedu ihe e choro eme?",
            "Ego foro na accounti gi",
            "Tinye Ego",
            "Were Ego",
            "Ziga Ego",
            "Tinye Ego n'Ekwenti",
            "Edemede ihe e megoro",
            "Kagbo",
            "Horo onuogugu",

            //UserScreen.cs/WithdrawalOption
            "Ego ne ka e choro ewere?",
            "Ego Ozo",
            "Horo nke obuna",

            //UserScreen.cs/AirtimeOption
            "Ego ne ka e choro etinye n'ekwenti?",

            //UserScreen.cs/RechargeChoice
            "Kedu onye e choro etinye ego n'ekwenti ya?",
            "Onwe m",
            "Onye ozo",

            //Atm[Atm1].cs/InsertTransaction --(2)
            "Tinye Ego",
            "Were Ego",
            "Ziga Ego",
            "Ego Ekwenti"
        }
    };
}