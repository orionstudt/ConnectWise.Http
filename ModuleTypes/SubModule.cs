using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.ModuleTypes
{
    /// <summary>
    /// Sub-Module endpoint class.
    /// Sub-Module in this context means the endpoint path is /[module]/[subModule]/{id?}
    /// </summary>
    public class SubModule
    {
        private string module;
        private string endpoint;

        internal SubModule(string module, string endpoint)
        {
            this.module = module;
            this.endpoint = endpoint;
        }

        protected string getPrefix()
        {
            return string.Format("{0}/{1}", module, endpoint);
        }  
    }

    /// <summary>
    /// Sub-Module endpoint class that contains GET, GETBYID, & COUNT.
    /// </summary>
    public class BaseSubModule : SubModule
    {
        internal BaseSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Generic GET request across the specified entities using the conditions provided.
        /// </summary>
        /// <param name="conditions">Standard CW Manage API conditions to be appended to the end of the request URL.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest GetRequest(CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.StandardConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, string.Format("{0}{1}", getPrefix(), conditionStr));
        }

        /// <summary>
        /// Generic GET request for the specified entity matching the provided ID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest GetRequest(int id, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, string.Format("{0}/{1}{2}", getPrefix(), id, conditionStr));
        }

        /// <summary>
        /// Generic GET request across the specified entities using the conditions provided.
        /// </summary>
        /// <param name="conditions">This endpoint only accepts 'Conditions' and 'CustomFieldConditions.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CountRequest(CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, string.Format("{0}/count{1}", getPrefix(), conditionStr));
        }
    }

    /// <summary>
    /// Sub-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, & UPDATE.
    /// </summary>
    public class UpdateSubModule : BaseSubModule
    {
        internal UpdateSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Generic PUT request replacing all fields on the entity matching the provided ID with the serialized fields supplied in 'content.'
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="content">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ReplaceRequest(int id, string content, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Put, string.Format("{0}/{1}{2}", getPrefix(), id, conditionStr), content);
        }

        /// <summary>
        /// Generic PATCH request updating specific fields on the entity matching the provided ID with the operations supplied in 'updates.'
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="updates">The list of Patch operations to be applied to the specified entity.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest UpdateRequest(int id, IEnumerable<CWPatch> updates, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            var patches = updates.Any() ? updates.ToList() : new List<CWPatch>();
            return new CWRequest(CWHttpMethod.Patch, string.Format("{0}/{1}{2}", getPrefix(), id, conditionStr), JsonConvert.SerializeObject(patches));
        }
    }

    /// <summary>
    /// Sub-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, UPDATE, & CREATE.
    /// </summary>
    public class CreateSubModule : UpdateSubModule
    {
        internal CreateSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Generic CREATE request for the specified entity type.
        /// </summary>
        /// <param name="content">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CreateRequest(string content, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Post, string.Format("{0}{1}", getPrefix(), conditionStr));
        }
    }

    /// <summary>
    /// Sub-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, UPDATE, CREATE, & DELETE.
    /// </summary>
    public class FullSubModule : CreateSubModule
    {
        internal FullSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Generic DELETE request for the entity matching the provided ID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DeleteRequest(int id)
        {
            return new CWRequest(CWHttpMethod.Delete, string.Format("{0}/{1}", getPrefix(), id));
        }
    }

    /// <summary>
    /// Sub-Module endpoint class that contains GET, GETBYID, COUNT, CREATE & DELETE.
    /// </summary>
    public class PartialSubModule : BaseSubModule
    {
        internal PartialSubModule(string module, string endpoint) : base(module, endpoint) { }

        /// <summary>
        /// Generic CREATE request for the specified entity's type.
        /// </summary>
        /// <param name="content">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CreateRequest(string content, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Post, string.Format("{0}{1}", getPrefix(), conditionStr));
        }

        /// <summary>
        /// Generic DELETE request for the specified entity matching the provided ID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DeleteRequest(int id)
        {
            return new CWRequest(CWHttpMethod.Delete, string.Format("{0}/{1}", getPrefix(), id));
        }
    }
}
