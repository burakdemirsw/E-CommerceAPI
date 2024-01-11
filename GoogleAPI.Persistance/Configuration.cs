namespace GoogleAPI.Persistance
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                //ConfigurationManager configurationManager = new();
                //configurationManager.SetBasePath(
                //    Path.Combine(Directory.GetCurrentDirectory(), "../../Googleapi/GoogleAPI.API")
                //);
                //configurationManager.AddJsonFile("appsettings.json");

                return "Data Source=192.168.2.36;Initial Catalog=MISIGOSHOPAPI;User ID=sa;Password=8969;TrustServerCertificate=True;";
            }
        }
    }
}
