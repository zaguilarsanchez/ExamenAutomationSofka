namespace ExamenAutomationSofka.Core.Config
{
    /**
     * Interfaz para leer configuraciones de diferentes archivos (JSON/Propiedades).
     */
    public interface IConfigReader
    { 
        string GetValue(string key);        
    }
}