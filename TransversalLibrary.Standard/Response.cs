using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TransversalLibrary.Standard
{
    /// <summary>
    /// Define el response de la función
    /// </summary>
    /// <typeparam name="T">Define el tipo genérico</typeparam>
    public class Response<T> : PropertyChangedBase
    {
        #region HTTP STATUS CODE

        /// <summary>
        /// Define el código de estado HTTP
        /// </summary>
        private HttpStatusCode? _HttpStatusCode = System.Net.HttpStatusCode.OK;

        /// <summary>
        /// Obtiene o establece el código de estado HTTP
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
        private string _Message = null;

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
        /// Define el contenido de la respuesta
        /// </summary>
        private T _Data = default(T);

        /// <summary>
        /// Obtiene o establece el contenido de la respuesta
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

        #region TOTAL

        /// <summary>
        /// Obtiene o establece el total de registros
        /// </summary>
        public long Total { get; set; } = 0;

        #endregion

        #region ERRORS

        /// <summary>
        /// Define los errores
        /// </summary>
        private List<string> _Errors = new List<string>();

        /// <summary>
        /// Obtiene o establece los errores
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

        /// <summary>
        /// Indica si tiene errores o no
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return Errors?.Any() == true || (HttpStatusCode != System.Net.HttpStatusCode.OK || HttpStatusCode != System.Net.HttpStatusCode.Accepted);
            }
        }

        #endregion

        #region CHANGE TYPE

        /// <summary>
        /// Cambia el tipo de la respuesta
        /// </summary>
        /// <typeparam name="Y">El tipo genérico al cambiar</typeparam>
        /// <returns>La respuesta con el nuevo tipo genérico</returns>
        public Response<Y> ChangeResponseType<Y>()
        {
            return new Response<Y>() { HttpStatusCode = this?.HttpStatusCode, Message = this?.Message, Errors = this?.Errors, Total = this?.Total ?? 0 };
        }

        #endregion

        #region GENERIC RESPONSE

        /// <summary>
        /// Retorna OK (200)
        /// </summary>
        /// <param name="message">El mensaje</param>
        /// <param name="data">El contenido</param>
        /// <param name="total">El total</param>
        /// <returns>La respuesta OK (200)</returns>
        public static Response<T> ReturnOK(string message, T data, long total = 0)
        {
            return new Response<T>() { HttpStatusCode = System.Net.HttpStatusCode.OK, Message = message, Data = data, Total = total };
        }

        /// <summary>
        /// Retorna BadRequest (400)
        /// </summary>
        /// <param name="errors">Los errores especificados</param>
        /// <returns>La respuesta de error BadRequest (400)</returns>
        public static Response<T> ReturnBadRequest(params string[] errors)
        {
            return new Response<T>() { HttpStatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Error", Errors = new List<string>(errors) };
        }

        /// <summary>
        /// Retorna Unauthorized (401)
        /// </summary>
        /// <param name="errors">Los errores especificados</param>
        /// <returns>La respuesta de error Unauthorized (401)</returns>
        public static Response<T> ReturnUnauthorized(params string[] errors)
        {
            return new Response<T>() { HttpStatusCode = System.Net.HttpStatusCode.Unauthorized, Message = "Error", Errors = new List<string>(errors) };
        }

        /// <summary>
        /// Retorna NotFound (404)
        /// </summary>
        /// <param name="errors">Los errores especificados</param>
        /// <returns>La respuesta de error NotFound (404)</returns>
        public static Response<T> ReturnNotFound(params string[] errors)
        {
            return new Response<T>() { HttpStatusCode = System.Net.HttpStatusCode.NotFound, Message = "Error", Errors = new List<string>(errors) };
        }

        /// <summary>
        /// Retorna InternalServerError (500)
        /// </summary>
        /// <param name="errors">Los errores especificados</param>
        /// <returns>La respuesta de error InternalServerError (500)</returns>
        public static Response<T> ReturnInternalServerError(params string[] errors)
        {
            return new Response<T>() { HttpStatusCode = System.Net.HttpStatusCode.InternalServerError, Message = "Error", Errors = new List<string>(errors) };
        }

        #endregion
    }
}