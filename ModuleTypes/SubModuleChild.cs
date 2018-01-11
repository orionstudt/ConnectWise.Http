using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.ModuleTypes
{
    /// <summary>
    /// Child-Module endpoint class.
    /// Child-Module in this context means the endpoint path is /[module]/[subModule]/{id}/[childModule]/{childId?}
    /// </summary>
    public class SubModuleChild
    {
        private string module;
        private string endpoint;
        private string child;

        internal SubModuleChild(string module, string endpoint, string child)
        {
            this.module = module;
            this.endpoint = endpoint;
            this.child = child;
        }

        protected string getPrefix(int id)
        {
            return $"{module}/{endpoint}/{id}/{child}";
        }
    }

    /// <summary>
    /// Child-Module endpoint class that contains GET, GETBYID.
    /// </summary>
    public class PartialBaseSubModuleChild : SubModuleChild
    {
        internal PartialBaseSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic GET request across the specified entity's child collection using the conditions provided.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="conditions">Standard CW Manage API conditions to be appended to the end of the request URL.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest GetRequest(int id, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.StandardConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix(id)}{conditionStr}");
        }

        /// <summary>
        /// Generic GET request for the specified entity's child matching the provided ChildID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest GetRequest(int id, int childId, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix(id)}/{childId}{conditionStr}");
        }
    }

    /// <summary>
    /// Child-Module endpoint class that contains GET, GETBYID, & COUNT.
    /// </summary>
    public class BaseSubModuleChild : PartialBaseSubModuleChild
    {
        internal BaseSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic GET request across the specified entity's child collection using the conditions provided.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="conditions">This endpoint only accepts 'Conditions' and 'CustomFieldConditions.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest CountRequest(int id, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix(id)}/count{conditionStr}");
        }
    }

    /// <summary>
    /// Child-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, & UPDATE.
    /// </summary>
    public class UpdateSubModuleChild : BaseSubModuleChild
    {
        internal UpdateSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic PUT request replacing all fields on the specified entity's child matching the provided ChildID with the serialized fields supplied in 'content.'
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="content">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest ReplaceRequest(int id, int childId, string content, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Put, $"{getPrefix(id)}/{childId}{conditionStr}", content);
        }

        /// <summary>
        /// Generic PATCH request updating specific fields on the entity's child matching the provided ChildID with the operations supplied in 'updates.'
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="updates">The list of Patch operations to be applied to the specified entity.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest UpdateRequest(int id, int childId, IEnumerable<CWPatch> updates, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            var patches = updates.Any() ? updates.ToList() : new List<CWPatch>();
            return new CWRequest(CWHttpMethod.Patch, $"{getPrefix(id)}/{childId}{conditionStr}", JsonConvert.SerializeObject(patches));
        }
    }

    /// <summary>
    /// Child-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, UPDATE, & CREATE.
    /// </summary>
    public class CreateSubModuleChild : UpdateSubModuleChild
    {
        internal CreateSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic CREATE request for the specified entity's child type.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="content">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest CreateRequest(int id, string content, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix(id)}{conditionStr}");
        }
    }

    /// <summary>
    /// Child-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, UPDATE, CREATE, & DELETE.
    /// </summary>
    public class FullSubModuleChild : CreateSubModuleChild
    {
        internal FullSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic DELETE request for the specified entity's child matching the provided ChildID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest DeleteRequest(int id, int childId)
        {
            return new CWRequest(CWHttpMethod.Delete, $"{getPrefix(id)}/{childId}");
        }
    }

    /// <summary>
    /// Child-Module endpoint class that contains GET, GETBYID, COUNT, CREATE & DELETE.
    /// </summary>
    public class PartialSubModuleChild : BaseSubModuleChild
    {
        internal PartialSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic CREATE request for the specified entity's child type.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="content">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest CreateRequest(int id, string content, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix(id)}{conditionStr}");
        }

        /// <summary>
        /// Generic DELETE request for the specified entity's child matching the provided ChildID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest DeleteRequest(int id, int childId)
        {
            return new CWRequest(CWHttpMethod.Delete, $"{getPrefix(id)}/{childId}");
        }
    }
}
