namespace Azure.Services.DataLake.Storage.Settings;

public class DataLakeStorageSetting
{
    public string StorageAccountName { get; set; }
    public string StorageAccountKey { get; set; }
    public string ServiceUri { get; set; }
    public string SharedKeyCredential { get; set; }
    public string StorageConnection { get; set; }
}
