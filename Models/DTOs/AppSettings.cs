namespace Models.DTOs
{
    public class ConnectionStrings
    {
        public string MainConnectionString { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public class SeedData
    {
        public bool SeedDataOnStart { get; set; }
        public string RelativeDirectory { get; set; }
    }

    public class LocalizationSettings
    {
        public bool LoadLocalizationOnStart { get; set; }
        public string LocalizationRelativePath { get; set; }
    }

    public class SwaggerToTypeScriptSettings
    {
        public string SourceDocumentAbsoluteUrl { get; set; }
        public string OutputDocumentRelativePath { get; set; }
    }

    public class FileSettings
    {
        public string RelativeDirectory { get; set; }
    }

    public class DocumentSettings
    {
        public string RelativeDirectory { get; set; }
        public string LaserFicheServer { get; set; }
        public string LaserFicheRepository { get; set; }
        public string LaserFicheUserName { get; set; }
        public string LaserFichePassword { get; set; }
    }

    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
        public SeedData SeedData { get; set; }
        public LocalizationSettings LocalizationSettings { get; set; }
        public SwaggerToTypeScriptSettings SwaggerToTypeScriptSettings { get; set; }
        public FileSettings FileSettings { get; set; }
        public DocumentSettings DocumentSettings { get; set; }
    }
}