using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TransversalLibrary
{
    /// <summary>
    /// Define la clase base para notificar que las propiedades de las clases heredadas han cambiado su valor
    /// </summary>
    public class PropertyChangedBase
    {
        #region PROPERTY CHANGED

        /// <summary>
        /// Define el evento que notifica que la propiedad ha cambiado
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifica que el valor de la propiedad especificada de esta clase ha cambiado
        /// </summary>
        public void OnPropertyChanged([CallerMemberName] string Name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

        #endregion
    }
}