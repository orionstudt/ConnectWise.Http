using ConnectWise.Http.ModuleTypes;

namespace ConnectWise.Http.Modules.Finance.SubModules
{
	public class ExportSubModule: PartialSubModule
	{
		internal ExportSubModule(string module, string endpoint) : base(module, endpoint) { }

		public CWRequest ExportRequest(object exportAccountingBatchRequest)
		{
			return new CWRequest(CWHttpMethod.Post, $"{getPrefix()}/export", exportAccountingBatchRequest);
		}
	}
}