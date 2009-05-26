using BancVue.Tests.Common;
using FluentObjectBuilder;
using NUnit.Framework;
using SampleApplication.DiscountCalculation;
using SampleApplication.Domain;
using SampleApplication.Domain.DiscountCalculation;
using SampleApplication.Tests.TestDataBuilders;


namespace SampleApplication.Tests.Tests.Domain.DiscountCalculation.DiscountCalculatorTests
{
	[ TestFixture ]
	public class When_calculating_a_tiered_discount : AutoRollbackDatabaseTest
	{
		private DiscountCalculator _calculator;


		protected override void TestSetUp()
		{
			IDiscountStrategy tieredDiscountStrategy = DiscountStrategyBuilder.BuildTieredStrategy()
					.Where.OrdersGreaterThanOrEqualTo( 100.dollars() ).GetDiscountOf( 10.percent() )
					.Build();

			_calculator = new DiscountCalculator( tieredDiscountStrategy );
		}


		[ Test ]
		public void For_an_order_less_than_100_dollars()
		{
			Order order = an.Order.With( a.LineItem.Costing( 10.dollars() ) )
					.build();

			_session.Save( order );
			_session.Flush();

			double discount = _calculator.CalculateDiscount( order );

			discount.should_be_equal_to( 10.cents() );
		}
	}
}