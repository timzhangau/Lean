/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/
using NUnit.Framework;
using QuantConnect.Indicators;

namespace QuantConnect.Tests.Indicators
{
    [TestFixture]
    public class MomentumPercentTests
    {
        [Test]
        public void ComputesCorrectly()
        {
            var momp = new MomentumPercent(50);
            double epsilon = 1e-3;
            TestHelper.TestIndicator(momp, "spy_with_roc50.txt", "Rate of Change 50", (ind, expected) => Assert.AreEqual(expected, (double)ind.Current.Value, epsilon));
        }

        [Test]
        public void ResetsProperly()
        {
            var momp = new MomentumPercent(50);
            foreach (var data in TestHelper.GetDataStream(51))
            {
                momp.Update(data);
            }
            Assert.IsTrue(momp.IsReady);

            momp.Reset();

            TestHelper.AssertIndicatorIsInDefaultState(momp);
        }
    }
}