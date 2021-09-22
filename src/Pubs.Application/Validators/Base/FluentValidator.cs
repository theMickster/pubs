using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pubs.Application.Validators.Base
{
    public abstract class FluentValidator<T> : AbstractValidator<T>
    {
        #region Private Fields

        private readonly Dictionary<Guid, ValidationFailure> _errors = new Dictionary<Guid, ValidationFailure>();

        #endregion Private Fields

        #region Public Methods

        public bool HasErrors => _errors.Count > 0;

        public Dictionary<Guid, ValidationFailure> Errors => _errors;

        #endregion Public Methods

        public Dictionary<Guid, ValidationFailure> ValidateProperties(T instance)
        {
            ValidateAndUpdateErrors(instance);
            return _errors;
        }

        /// <summary>
        /// Retrieves a list of all errors for a given property or all errors if no property name was specified.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return GetAllErrors();
            }

            var propertyInfo = typeof(T).GetRuntimeProperty(propertyName);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property name {propertyName} does not exist in {typeof(T)}", propertyName);
            }

            return _errors
                .Where(x => x.Value.PropertyName == propertyName &&
                        x.Value.Severity == Severity.Error)
                .Select(y => y.Value.ErrorMessage).ToList();
        }

        /// <summary>
        /// Retrieves a list of all warnings for a given property or all errors if no property name was specified.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetWarningss(string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return GetAllWarnings();
            }

            var propertyInfo = typeof(T).GetRuntimeProperty(propertyName);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property name {propertyName} does not exist in {typeof(T)}", propertyName);
            }

            return _errors
                .Where(x => x.Value.PropertyName == propertyName && x.Value.Severity == Severity.Warning)
                .Select(y => y.Value.ErrorMessage).ToList();
        }


        /// <summary>
        /// Retrieves a list of all error messages for a validator's validations.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllErrors()
        {
            return _errors
                .Where(x => x.Value.Severity == Severity.Error)
                .Select(error => error.Value.ErrorMessage).ToList();
        }

        /// <summary>
        /// Retrieves a list of all warning messages for a validator's validations.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllWarnings()
        {
            return _errors
                .Where(x => x.Value.Severity == Severity.Warning)
                .Select(y => y.Value.ErrorMessage).ToList();
        }

        #region Private Methods

        private void ValidateAndUpdateErrors(T instance)
        {
            _errors.Clear();

            foreach (var error in Validate(instance).Errors)
            {
                _errors.Add(Guid.NewGuid(), error);
            }
        }

        #endregion Private Methods
    }
}
