// Copyright 2011 Chris Edwards
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using Fluency.Utils;
using NUnit.Framework;
using SampleApplication.Domain;
using SampleApplication.Tests.FluentBuilders;
using SharpTestsEx;


namespace SampleApplication.Tests.UnitTests.Domain.OrderTests
{
	[ TestFixture ]
	public class When_getting_the_total_order_amount
	{
		[ Test ]
		public void For_a_single_line_item_Should_return_the_amount_for_that_line_item()
		{
			Order order = an.Order.With( a.LineItem.Costing( 10.dollars() ) )
					.build();

			order.TotalAmount.Should().Be.EqualTo( 10.dollars() );
		}
	}
}