using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Charts
{
    public class Service1 : ICharts
    {
        public string Chart(string chartLabel, string[] dataLabels, string[] dataValues)
        {

            // add quotes to strings so javascript doesn't interpret them as variables
            // also escape single quotes so we don't break out of the js string when the input contains '
            var quotedValues = dataValues.Select(el => $"'{el.Replace("'", "\\'")}'");
            var quotedLabels = dataLabels.Select(el => $"'{el.Replace("'", "\\'")}'");
            chartLabel = chartLabel.Replace("'", "\\'");

            // join the string arrays with a comma seperated
            var joinedValues = String.Join(",", quotedValues);
            var joinedLabels = String.Join(",", quotedLabels);

            // use chart.js by importing from a cdn and injecting our parameters
            string html = $@"
                        <div>
                        <script src='https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.4.1/chart.umd.js' integrity='sha512-ZwR1/gSZM3ai6vCdI+LVF1zSq/5HznD3ZSTk7kajkaj4D292NLuduDCO1c/NT8Id+jE58KYLKT7hXnbtryGmMg==' crossorigin='anonymous' referrerpolicy='no-referrer'></script>
                            <div>
                          <canvas id='myChart'></canvas>
                        </div>
                        <script>
                          const ctx = document.getElementById('myChart');
                          new Chart(ctx, {@"{
                            type: 'line',
                            data: {
                              labels: [" + joinedLabels + @"],
                              datasets: [{
                                label: '" + chartLabel + @"',
                                data: [" + joinedValues + @"],
                                borderWidth: 1
                              }]
                            },
                            options: {
                              scales: {
                                y: {
                                  beginAtZero: false
                                }
                              }
                            }
                          });"}
                        </script>
                    </div>
                          ";
            return html;
        }
    }
}
