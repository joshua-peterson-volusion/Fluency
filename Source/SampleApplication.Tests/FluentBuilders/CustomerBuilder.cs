using Fluency;
using Fluency.DataGeneration;
using SampleApplication.Domain;


namespace SampleApplication.Tests.FluentBuilders
{
	public class CustomerBuilder : FluentBuilder< Customer >
	{
		protected override void SetupDefaultValues()
		{
			SetProperty( x => x.Id, GenerateNewId() );
			SetProperty( x=>x.FirstName, ARandom.FirstName() );
			SetProperty( x=>x.LastName, ARandom.LastName() );
		}


		protected override Customer BuildFrom( Customer values )
		{
			return new Customer
			       	{
			       			Id = values.Id,
			       			FirstName = values.FirstName,
			       			LastName = values.LastName
			       	};
		}
	}
}