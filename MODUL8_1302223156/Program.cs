// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class BankTransferConfig
{
    public string lang_bank { get; set; }
    public transfer transfer_bank { get; set; }
    public List<string> metode_bank { get; set; }
    public BTConfirmation konfirmasi_bank { get; set; }


    public BankTransferConfig(string lang_bank, transfer transfer_bank, List<string> metode_bank, BTConfirmation konfirmasi_bank) { 
        this.lang_bank = lang_bank;
        this.transfer_bank = transfer_bank;
        this.metode_bank = metode_bank;
        this.konfirmasi_bank= konfirmasi_bank;
    }

    public class transfer
    {
        public double threshold { get; set; }
        public double low_fee { get; set; }
        public double high_fee { get; set; }


        public transfer(double threshold, double low_fee, double high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }
    public class BTConfirmation
    {
        public string en { get; set; }
        public string id { get; set; }

        public BTConfirmation() { }

        public BTConfirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
}

public class DataBank { 
    public BankTransferConfig Config { get; set; }
    private string fileName = "bank_transfer_config.json";
    public DataBank()
    {
        try {
            ReadConfig();
        }
        catch (FileNotFoundException)
        {
            WriteNewConfig();
        }
        catch (JsonException)
        {
            Console.WriteLine("File konfigurasi tidak valid. Membuat konfigurasi default.");
            WriteNewConfig();
        }
    }
    private BankTransferConfig ReadConfig()
    {

        string configJsonString = File.ReadAllText(@"C:\Users\daffa\Documents\File semester 4\TP KPL\Jurnal\MODUL8_1302223156\Bank_Transfer_config.JSON" + "/" + fileName);
        Config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonString);
        return Config;
    }

    private void WriteNewConfig()
    {
        JsonSerializerOptions opts = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        string jsonString = JsonSerializer.Serialize(Config, opts);
        File.WriteAllText(@"C:\Users\daffa\Documents\File semester 4\TP KPL\Jurnal\MODUL8_1302223156\Bank_Transfer_config.JSON", jsonString);
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        String langu;

        DataBank defaultConf = new DataBank();

        if (defaultConf.Config.lang_bank == "en")
        {
            Console.Write("Please insert the amount of money to transfer: ");
        }
        else if (defaultConf.Config.lang_bank == "id") ;
    }
}
