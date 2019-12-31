using ConnectWise.Http.ModuleTypes;

namespace ConnectWise.Http.Modules.Finance.SubModules
{
	public class AccountingSubModule : SubModule
	{
		internal AccountingSubModule(string module, string endpoint) : base(module, endpoint) { }
		/// <summary>
		/// posts to endpoint /accounting/export
		/// Required before doing a definite export using AccountingBatches
		/// </summary>
		/// <param name="exportAccountingBatchRequest">your AccountingBatchRequest instance</param>
		public CWRequest ExportRequest(object exportAccountingBatchRequest)
		{
			return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/export", exportAccountingBatchRequest);
		}
		/// <summary>
		/// posts to endpoint /accounting/export
		/// Required before doing a definite export using AccountingBatches
		/// </summary>
		/// <param name="exportAccountingBatchRequest">your AccountingBatchRequest serialized JSON instance</param>
		public CWRequest ExportRequest(string serializedExportAccountingBatchRequest)
		{
			return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/export", serializedExportAccountingBatchRequest);
		}
	}
}