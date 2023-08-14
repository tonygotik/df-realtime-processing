using Azure.Services.DataLake.Storage.Settings;
using Azure.Storage;
using Azure.Storage.Files.DataLake;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;

namespace Azure.Services.DataLake.Storage;

public class DataLakeStorageManager : IDataLakeStorageManager
{
    private readonly DataLakeStorageSetting _options;

    public DataLakeStorageSetting Options => _options;
    private DataLakeFileSystemClient _fileSystem;
    public DataLakeStorageManager(IOptions<DataLakeStorageSetting> options)
    {
        _options = options.Value;

        DataLakeServiceClient serviceClient = new DataLakeServiceClient(_options.StorageConnection);

        _fileSystem = serviceClient.GetFileSystemClient("dms");
    }

    public async Task<DataLakeFileClient> CreateStorageFileClient(string path, string filename)
    {
        DataLakePathClient pathClient = _fileSystem.CreateFile(path);
        pathClient.AddBlobServiceClient();

        DataLakeFileClient file = directory.CreateFile(filename);
        file.;

        await _fileSystem.CreateIfNotExistsAsync();
    }
}
