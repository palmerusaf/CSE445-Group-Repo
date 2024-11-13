﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_client.ChartService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChartService.ICharts")]
    public interface ICharts {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharts/Chart", ReplyAction="http://tempuri.org/ICharts/ChartResponse")]
        string Chart(string chartLabel, string[] dataLabels, string[] dataValues);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICharts/Chart", ReplyAction="http://tempuri.org/ICharts/ChartResponse")]
        System.Threading.Tasks.Task<string> ChartAsync(string chartLabel, string[] dataLabels, string[] dataValues);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChartsChannel : web_client.ChartService.ICharts, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChartsClient : System.ServiceModel.ClientBase<web_client.ChartService.ICharts>, web_client.ChartService.ICharts {
        
        public ChartsClient() {
        }
        
        public ChartsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChartsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChartsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChartsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Chart(string chartLabel, string[] dataLabels, string[] dataValues) {
            return base.Channel.Chart(chartLabel, dataLabels, dataValues);
        }
        
        public System.Threading.Tasks.Task<string> ChartAsync(string chartLabel, string[] dataLabels, string[] dataValues) {
            return base.Channel.ChartAsync(chartLabel, dataLabels, dataValues);
        }
    }
}