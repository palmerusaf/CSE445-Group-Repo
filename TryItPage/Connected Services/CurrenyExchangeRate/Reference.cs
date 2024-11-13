﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_client.CurrenyExchangeRate {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CurrenyExchangeRate.ICurrencyExchange")]
    public interface ICurrencyExchange {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICurrencyExchange/ExchangeRate", ReplyAction="http://tempuri.org/ICurrencyExchange/ExchangeRateResponse")]
        string ExchangeRate(string cur1, string cur2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICurrencyExchange/ExchangeRate", ReplyAction="http://tempuri.org/ICurrencyExchange/ExchangeRateResponse")]
        System.Threading.Tasks.Task<string> ExchangeRateAsync(string cur1, string cur2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICurrencyExchangeChannel : web_client.CurrenyExchangeRate.ICurrencyExchange, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CurrencyExchangeClient : System.ServiceModel.ClientBase<web_client.CurrenyExchangeRate.ICurrencyExchange>, web_client.CurrenyExchangeRate.ICurrencyExchange {
        
        public CurrencyExchangeClient() {
        }
        
        public CurrencyExchangeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CurrencyExchangeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CurrencyExchangeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CurrencyExchangeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ExchangeRate(string cur1, string cur2) {
            return base.Channel.ExchangeRate(cur1, cur2);
        }
        
        public System.Threading.Tasks.Task<string> ExchangeRateAsync(string cur1, string cur2) {
            return base.Channel.ExchangeRateAsync(cur1, cur2);
        }
    }
}
