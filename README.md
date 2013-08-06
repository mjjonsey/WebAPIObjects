WebAPIObjects
=============

Object library for the Tradestation WebAPI

History: 

07/23/2013  Fixed ForexAccountCurrencyDetail which was supposed to be a superclass of AccountCurrencyDetail
06/28/2013	Set the Json property name of GroupOrder.GroupOrderType to "Type"  
06/28/2013	Changed the Position.OpenProfitLossQty property to decimal from int.  
06/28/2013	Changed the Order.TimeStamp property to DateTime from string.  
06/28/2013	Modified AccessToken to fire an event, ExpirationWarning, one time when the token is within 120 seconds of expiration. This event can be used by the client to proactively request a new token before the current one expires.  
06/28/2013	Modified AccessToken so the ExpiresIn returns a value which counts down from when the token was issued.  
06/13/2013	Added SymbolBarData, a superclass of IntradayBarData  
06/13/2013	Added new value to OrderState enum: UCH - Replaced  
06/07/2013	Added ExchangeId to Symbol object.  
05/15/2013	Initial checkin of project.  
