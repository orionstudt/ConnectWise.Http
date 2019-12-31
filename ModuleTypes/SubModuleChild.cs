using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.ModuleTypes
{
    /// <summary>
    /// Child-Module endpoint class. Child-Module in this context means the endpoint path is /[module]/[subModule]/{id}/[childModule]/{childId?}
    /// </summary>
    public abstract class SubModuleChild
    {
        private readonly string module;
        private readonly string endpoint;
        private readonly string child;

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
    public class PartialGetSubModuleChild : SubModuleChild
    {
        internal PartialGetSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic GET request across the specified entity's child collection using the conditions provided.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="conditions">Standard CW Manage API conditions to be appended to the end of the request URL.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest GetRequest(int id, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.StandardConditions) : string.Empty;
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
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix(id)}/{childId}{conditionStr}");
        }
    }

    /// <summary>
    /// Child-Module endpoint class that contains GET & COUNT.
    /// </summary>
    public class BaseSubModuleChild : SubModuleChild
    {
        internal BaseSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic GET request across the specified entity's child collection using the conditions provided.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="conditions">Standard CW Manage API conditions to be appended to the end of the request URL.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest GetRequest(int id, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.StandardConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix(id)}{conditionStr}");
        }

        /// <summary>
        /// Generic GET request across the specified entity's child collection using the conditions provided.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="conditions">This endpoint only accepts 'Conditions' and 'CustomFieldConditions.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest CountRequest(int id, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix(id)}/count{conditionStr}");
        }
    }

    /// <summary>
    /// Child-Module endpoint class that contains GET, GETBYID, & COUNT.
    /// </summary>
    public class GetSubModuleChild : BaseSubModuleChild
    {
        internal GetSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic GET request for the specified entity's child matching the provided ChildID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest GetRequest(int id, int childId, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix(id)}/{childId}{conditionStr}");
        }
    }

    /// <summary>
    /// Child-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, & UPDATE.
    /// </summary>
    public class UpdateSubModuleChild : GetSubModuleChild
    {
        internal UpdateSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic PUT request replacing all fields on the specified entity's child matching the provided ChildID with the serialized fields supplied in 'content.'
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="serializedContent">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest ReplaceRequest(int id, int childId, string serializedContent, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Put, $"{getPrefix(id)}/{childId}{conditionStr}", serializedContent);
        }

        /// <summary>
        /// Generic PUT request replacing all fields on the specified entity's child matching the provided ChildID with the serialized fields supplied in 'content.'
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="content">The object to be serialized & sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest ReplaceRequest(int id, int childId, object content, CWRequestConditions conditions = null)
        {
            return ReplaceRequest(id, childId, JsonConvert.SerializeObject(content), conditions);
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
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.OnlyFields) : string.Empty;
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
        /// <param name="serializedContent">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest CreateRequest(int id, string serializedContent, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix(id)}{conditionStr}", serializedContent);
        }

        /// <summary>
        /// Generic CREATE request for the specified entity's child type.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="content">The object to be serialized & sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest CreateRequest(int id, object content, CWRequestConditions conditions = null)
        {
            return CreateRequest(id, JsonConvert.SerializeObject(content), conditions);
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
    /// Child-Module endpoint class that contains GET, COUNT, CREATE & DELETE.
    /// </summary>
    public class PartialDeleteSubModuleChild : BaseSubModuleChild
    {
        internal PartialDeleteSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic CREATE request for the specified entity's child type.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="serializedContent">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest CreateRequest(int id, string serializedContent, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Post, $"{getPrefix(id)}{conditionStr}", serializedContent);
        }

        /// <summary>
        /// Generic CREATE request for the specified entity's child type.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="content">The object to be serialized & sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest CreateRequest(int id, object content, CWRequestConditions conditions = null)
        {
            return CreateRequest(id, JsonConvert.SerializeObject(content), conditions);
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

    /// <summary>
    /// Child-Module endpoint class that contains GET, GETBYID, COUNT, CREATE & DELETE.
    /// </summary>
    public class PartialSubModuleChild : PartialDeleteSubModuleChild
    {
        internal PartialSubModuleChild(string module, string endpoint, string child) : base(module, endpoint, child) { }

        /// <summary>
        /// Generic GET request for the specified entity's child matching the provided ChildID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public virtual CWRequest GetRequest(int id, int childId, CWRequestConditions conditions = null)
        {
            var conditionStr = conditions != null ? conditions.ToUriConditions(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, $"{getPrefix(id)}/{childId}{conditionStr}");
        }
    }
}
