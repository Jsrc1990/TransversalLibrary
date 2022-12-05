using System.Collections.Generic;
using System.Net;

namespace TransversalLibrary
{
    /// <summary>
    /// Define el response de la función
    /// </summary>
    /// <typeparam name="T">Define el tipo genérico</typeparam>
    public class Response<T> : PropertyChangedBase
    {
        #region HTTP STATUS CODE

        /// <summary>
        /// Define el código de estado Http
        /// </summary>
        private HttpStatusCode? _HttpStatusCode;

        /// <summary>
        /// Obtiene o establece el código de estado Http
        /// </summary>
        public HttpStatusCode? HttpStatusCode
        {
            get
            {
                return _HttpStatusCode;
            }
            set
            {
                _HttpStatusCode = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region MESSAGE

        /// <summary>
        /// Define el mensaje de la respuesta
        /// </summary>
        private string _Message = string.Empty;

        /// <summary>
        /// Obtiene o establece el mensaje de la respuesta
        /// </summary>
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region DATA

        /// <summary>
        /// Define el objeto de respuesta
        /// </summary>
        private T _Data = default(T);

        /// <summary>
        /// Obtiene o establece el objeto de respuesta
        /// </summary>
        public T Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region ERRORS

        /// <summary>
        /// Define los errores
        /// </summary>
        private List<string> _Errors = new List<string>();

        /// <summary>
        /// Obtiene los errores
        /// </summary>
        public List<string> Errors
        {
            get
            {
                return _Errors;
            }
            set
            {
                _Errors = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
