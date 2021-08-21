using Newtonsoft.Json;
using System;
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

        #region EXCEPTION

        /// <summary>
        /// Obtiene o establece la excepción
        /// </summary>
        [JsonIgnore()]
        public Exception Exception { get; set; }

        /// <summary>
        /// Define el mensaje de la excepción
        /// </summary>
        [JsonProperty(nameof(Exception))]
        public string MessageException
        {
            get
            {
                return Exception?.Message;
            }
        }

        #endregion

        #region ERRORS

        /// <summary>
        /// Obtiene los errores
        /// </summary>
        public List<string> Errors { get; } = new List<string>();

        #endregion
    }
}
