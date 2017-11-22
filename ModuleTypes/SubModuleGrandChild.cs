﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http.ModuleTypes
{
    /// <summary>
    /// GrandChild-Module endpoint class.
    /// GrandChild-Module in this context means the endpoint path is /[module]/[subModule]/{id}/[childModule]/{childId}/[grandChildModule]/{grandChildId?}
    /// </summary>
    public class SubModuleGrandChild
    {
        private string module;
        private string endpoint;
        private string child;
        private string grandChild;

        internal SubModuleGrandChild(string module, string endpoint, string child, string grandChild)
        {
            this.module = module;
            this.endpoint = endpoint;
            this.child = child;
            this.grandChild = grandChild;
        }

        protected string getPrefix(int id, int childId)
        {
            return string.Format("{0}/{1}/{2}/{3}/{4}/{5}", module, endpoint, id, child, childId, grandChild);
        }
    }

    /// <summary>
    /// GrandChild-Module endpoint class that contains GET, GETBYID, & COUNT.
    /// </summary>
    public class BaseSubModuleGrandChild : SubModuleGrandChild
    {
        internal BaseSubModuleGrandChild(string module, string endpoint, string child, string grandChild) : base(module, endpoint, child, grandChild) { }

        /// <summary>
        /// Generic GET request across the specified entity's grandchild collection using the conditions provided.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="conditions">Standard CW Manage API conditions to be appended to the end of the request URL.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest GetRequest(int id, int childId, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.StandardConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, string.Format("{0}{1}", getPrefix(id, childId), conditionStr));
        }

        /// <summary>
        /// Generic GET request for the specified entity's grandchild matching the provided GrandChildID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="grandChildId">The specified entity's grandchild ID.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest GetRequest(int id, int childId, int grandChildId, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, string.Format("{0}/{1}{2}", getPrefix(id, childId), grandChildId, conditionStr));
        }

        /// <summary>
        /// Generic GET request across the specified entity's grandchild collection using the conditions provided.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="conditions">This endpoint only accepts 'Conditions' and 'CustomFieldConditions.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CountRequest(int id, int childId, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Get, string.Format("{0}/count{1}", getPrefix(id, childId), conditionStr));
        }
    }

    /// <summary>
    /// GrandChild-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, & UPDATE.
    /// </summary>
    public class UpdateSubModuleGrandChild : BaseSubModuleGrandChild
    {
        internal UpdateSubModuleGrandChild(string module, string endpoint, string child, string grandChild) : base(module, endpoint, child, grandChild) { }

        /// <summary>
        /// Generic PUT request replacing all fields on the specified entity's grandchild matching the provided GrandChildID with the serialized fields supplied in 'content.'
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="grandChildId">The specified entity's grandchild ID.</param>
        /// <param name="content">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest ReplaceRequest(int id, int childId, int grandChildId, string content, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            return new CWRequest(CWHttpMethod.Put, string.Format("{0}/{1}{2}", getPrefix(id, childId), grandChildId, conditionStr), content);
        }

        /// <summary>
        /// Generic PATCH request updating specific fields on the specified entity's grandchild matching the provided GrandChildID with the operations supplied in 'updates.'
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="grandChildId">The specified entity's grandchild ID.</param>
        /// <param name="updates">The list of Patch operations to be applied to the specified entity.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest UpdateRequest(int id, int childId, int grandChildId, IEnumerable<CWPatch> updates, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.OnlyFields) : string.Empty;
            var patches = updates.Any() ? updates.ToList() : new List<CWPatch>();
            return new CWRequest(CWHttpMethod.Patch, string.Format("{0}/{1}{2}", getPrefix(id, childId), grandChildId, conditionStr), JsonConvert.SerializeObject(patches));
        }
    }

    /// <summary>
    /// GrandChild-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, UPDATE, & CREATE.
    /// </summary>
    public class CreateSubModuleGrandChild : UpdateSubModuleGrandChild
    {
        internal CreateSubModuleGrandChild(string module, string endpoint, string child, string grandChild) : base(module, endpoint, child, grandChild) { }

        /// <summary>
        /// Generic CREATE request for the specified entity's grandchild type.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="content">The serialized data to be sent in the body of the request.</param>
        /// <param name="conditions">This endpoint only accepts 'Fields.'</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest CreateRequest(int id, int childId, string content, CWRequestConditions conditions = null)
        {
            string conditionStr = conditions != null ? conditions.Build(CWConditionOptions.CountConditions) : string.Empty;
            return new CWRequest(CWHttpMethod.Post, string.Format("{0}{1}", getPrefix(id, childId), conditionStr));
        }
    }

    /// <summary>
    /// GrandChild-Module endpoint class that contains GET, GETBYID, COUNT, REPLACE, UPDATE, CREATE, & DELETE.
    /// </summary>
    public class FullSubModuleGrandChild : CreateSubModuleGrandChild
    {
        internal FullSubModuleGrandChild(string module, string endpoint, string child, string grandChild) : base(module, endpoint, child, grandChild) { }

        /// <summary>
        /// Generic DELETE request for the specified entity's grandchild matching the provided GrandChildID.
        /// </summary>
        /// <param name="id">The specified entity ID.</param>
        /// <param name="childId">The specified entity's child ID.</param>
        /// <param name="grandChildId">The specified entity's grandchild ID.</param>
        /// <returns>CWRequest to be sent using CWHttpClient.</returns>
        public CWRequest DeleteRequest(int id, int childId, int grandChildId)
        {
            return new CWRequest(CWHttpMethod.Delete, string.Format("{0}/{1}", getPrefix(id, childId), grandChildId));
        }
    }
}