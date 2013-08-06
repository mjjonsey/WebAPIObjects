using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using Newtonsoft.Json;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class AssetTypeConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType)
		{
			return typeof(AssetType).IsAssignableFrom(objectType);
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanWrite
		{
			get { return true; }
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			AssetType assetType = AssetType.EQ; 
		string value = reader.Value.ToString().ToUpper();
			if (value.Contains("OPTION"))
				assetType = AssetType.OP;
			else 
			{
				switch (value)
				{
					case "STOCK":
						assetType = AssetType.EQ;
						break;
					case "INDEX":
						assetType = AssetType.IX;
						break;
					case "FUTURE":
						assetType = AssetType.FU;
						break;
					case "FOREX":
						assetType = AssetType.FX;
						break;
					case "UNKNOWN":
						assetType = AssetType.UK;
						break;
					default: 
						Debug.Fail("No matching asset type found, defaulting to EQ"); 
						break;
				}
			}

			return assetType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			AssetType assetType = (AssetType)value;
			switch (assetType)
			{ 
				case AssetType.EQ:
					writer.WriteValue("STOCK");
					break;
				case AssetType.FU:
					writer.WriteValue("FUTURE");
					break; 
				case AssetType.FX:
					writer.WriteValue("FOREX");
					break;
				case AssetType.OP:
					writer.WriteValue("OPTION");
					break;
				default:
					writer.WriteValue(string.Empty);
					break;
			}
		}
	}

	public class CountryCodeConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType)
		{
			return typeof(CountryCode).IsAssignableFrom(objectType);
		}

		/// <summary>
		/// Thie class will read strings and convert them to the appropriate country code
		/// </summary>
		public override bool CanRead
		{
			get { return true; }
		}

		/// <summary>
		/// No need to implement CanWrite(), ToString() will give the appropriate value
		/// </summary>
		public override bool CanWrite
		{
			get { return false; }
		}

		/// <summary>
		/// Reads string and returns country code. Defaults to US
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="objectType"></param>
		/// <param name="existingValue"></param>
		/// <param name="serializer"></param>
		/// <returns></returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			CountryCode code = CountryCode.US;
			switch (reader.Value.ToString().ToUpper().Replace(" ", ""))
			{
				case "US":
				case "USA":
				case "UNITEDSTATES":
					code = CountryCode.US;
					break;
				case "DE":
				case "GERMANY":
					code = CountryCode.DE;
					break;
				case "CA":
				case "CANADA":
					code = CountryCode.CA;
					break;
			}

			return code;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException(); 
		}
	}
	/*
	public class CurrencyConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType)
		{
			return typeof(Currency).IsAssignableFrom(objectType);
		}

		/// <summary>
		/// Thie class will read strings and convert them to the appropriate currency code
		/// </summary>
		public override bool CanRead
		{
			get { return true; }
		}

		/// <summary>
		/// No need to implement CanWrite(), ToString() will give the appropriate value
		/// </summary>
		public override bool CanWrite
		{
			get { return false; }
		}

		/// <summary>
		/// Reads string and returns currency code. Defaults to USD
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="objectType"></param>
		/// <param name="existingValue"></param>
		/// <param name="serializer"></param>
		/// <returns></returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			Currency code = Currency.USD;
			switch (reader.Value.ToString().ToUpper().Replace(" ", ""))
			{
				case "US":
				case "USA":
				case "UNITEDSTATES":
					code = CountryCode.US;
					break;
				case "DE":
				case "GERMANY":
					code = CountryCode.DE;
					break;
				case "CA":
				case "CANADA":
					code = CountryCode.CA;
					break;
			}

			return code;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
	*/

	public class OrderConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType)
		{
			return typeof(Order).IsAssignableFrom(objectType);
		}

		public override bool CanRead
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return true; }
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			Order order = (Order)value;

			#region sample json
			/*
			

				{
				"AssetType":"EQ",
				"Symbol":"ARNA",
				"Quantity":"10",
				"LimitPrice":".25",
				"OrderType":"Limit",
				"Duration":"DYP",
				"AccountKey":"123456",
				"TradeAction":"Buy",
				"AdvancedOptions":{"TrailingStop":null},
				"OSOs":[
				  {"Type":"NORMAL",
				   "Orders":[
					 {"AssetType":"EQ", 
					  "Symbol":"ARNA",
					  "Quantity":"10",
					  "LimitPrice":"1.25",
					  "OrderType":"Limit",
					  "Duration":"DYP",
					  "AccountKey":"123456",
					  "TradeAction":"Sell",
					  "AdvancedOptions":{"TrailingStop":null},
					  "OSOs":[]}
				   ]}
				]}
			  
				 {
				"AccountKey":"123456",
				"AssetType":"EQ",
				"Duration":"DAY",
				"GTDDate":"",
				"LimitPrice":"10.00",
				"OrderID":"",
				"OrderType":"Limit",
				"Quantity":"10",
				"Route":"Intelligent",
				"StopPrice":"0.00",
				"Symbol":"GOOG",
				"TradeAction":"Buy"
				}
			 */
			#endregion sample json
			writer.WriteStartObject();
			writer.WritePropertyName("AssetType");
			writer.WriteValue(order.AssetType.ToString());

			writer.WritePropertyName("Symbol");
			writer.WriteValue(order.Symbol);

			writer.WritePropertyName("Quantity");
			writer.WriteValue(order.Quantity.ToString());

			writer.WritePropertyName("LimitPrice");
			writer.WriteValue(order.LimitPrice > 0 ? order.LimitPrice.ToString() : "");

			writer.WritePropertyName("OrderType");
			writer.WriteValue(order.OrderType.ToString());

			writer.WritePropertyName("Duration");
			writer.WriteValue(order.Duration.ToString());

			if (order.GTDDate > DateTime.MinValue && order.GTDDate < DateTime.MaxValue)
			{
				writer.WritePropertyName("GTDDate");
				writer.WriteValue(order.GTDDate.ToShortDateString()); 
			}

			if (order.OrderId > 0)
			{
				writer.WritePropertyName("OrderID");
				writer.WriteValue(order.OrderId.ToString());
			}

			if (order.Route != Route.Intelligent)
			{
				writer.WritePropertyName("Route");
				writer.WriteValue(order.Route.ToString());
			}

			if (order.StopPrice > 0)
			{
				writer.WritePropertyName("StopPrice");
				writer.WriteValue(order.StopPrice.ToString());
			}
			
			writer.WritePropertyName("AccountKey");
			writer.WriteValue(order.AccountKey);

			writer.WritePropertyName("TradeAction"); 
			writer.WriteValue(order.TradeAction.ToString());

			// TODO: Advanced options skipped
			if (order.OSOs.Count > 0)
			{
				writer.WritePropertyName("OSOs");
				writer.WriteStartArray();
				foreach (GroupOrder group in order.OSOs)
				{
					writer.WriteStartObject();
					writer.WritePropertyName("Type");
					writer.WriteValue(group.GroupType.ToString());

					writer.WritePropertyName("Orders");
					writer.WriteStartArray();

					for (int i = 0; i < group.Orders.Count; i++)
					{
						Order innerOrder = group.Orders[i];
						WriteJson(writer, innerOrder, serializer);
						//if (i < group.Orders.Count -1) writer.WriteRaw(",");
					}

					writer.WriteEndArray();
				}
				writer.WriteEndObject();
				writer.WriteEndArray();
			}
			

			writer.WriteEndObject(); 
		}
	}

	public class OrderDurationConverter : JsonConverter
	{
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType.IsAssignableFrom(typeof(OrderDuration));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null) throw new ArgumentException("Unable to write null OrderDuration to Json.", "value");

			OrderDuration duration = value as OrderDuration;
			StringBuilder text = new StringBuilder(64);
			if (duration != null)
			{
				text.Append(duration.Code.ToString());
				if (duration.Expiration.HasValue && duration.Expiration > DateTime.MinValue)
					text.AppendFormat(" - {0}", ((DateTime)duration.Expiration).ToShortDateString());
			}

			// caller will already write the start object and property name
			writer.WriteValue(text.ToString());

			/*
			writer.WriteStartObject();
			writer.WritePropertyName("Duration");
			writer.WriteValue(text.ToString());
			writer.WriteEndObject();
			 */
		}
	}

	public class V2TokenReader : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(AccessToken).IsAssignableFrom(objectType);
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// {"access_token":"dG1..9","expires_in":1200,"token_type":"AccessToken","userid":"bbowen"}
			AccessToken token = new AccessToken();
			while (reader.Read())
			{
				if (reader.Value != null)
				{
					switch (reader.Value.ToString())
					{
						case "access_token":
							if (reader.Read()) token.Token = reader.Value.ToString();
							break;
						case "expires_in":
							if (reader.Read())
							{
								int test;
								int.TryParse(reader.Value.ToString(), out test);
								token.ExpiresIn = test;
							}
							break;
						case "token_type":
							if (reader.Read()) token.Type = reader.Value.ToString();
							break;
						case "userid":
							if (reader.Read()) token.UserId = reader.Value.ToString();
							break;
						default:
							reader.Read();
							break;
					}
				}
				else
					break;
			}

			return token;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();

		}
	}


	public class OrderRequestWriter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(OrderRequest).IsAssignableFrom(objectType);
		}

		public override bool CanRead
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return true; }
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			OrderRequest request = value as OrderRequest;
			if (request == null) throw new ArgumentException(string.Format("Can not serialize {0} with OrderRequestWriter.", value.GetType().Name), "value");

			string format;
			switch (request.AssetType)
			{
				case AssetType.FX:
					format = request.Symbol.ToUpper().Trim() == "USDJPY" ? "0.000" : "0.00000";
					break;
				default:
					format = "0.00";
					break;
			}

			writer.WriteStartObject();
			writer.WritePropertyName("AccountKey");
			writer.WriteValue(request.AccountKey);
			writer.WritePropertyName("AssetType");
			writer.WriteValue(request.AssetType.ToString());
			writer.WritePropertyName("Duration");
			writer.WriteValue(request.Duration.ToString());
			writer.WritePropertyName("GTDDate");
			writer.WriteValue(request.GTDDate > DateTime.MinValue ? request.GTDDate.ToShortDateString() : "");
			writer.WritePropertyName("LimitPrice");
			writer.WriteValue(request.LimitPrice > 0 ? request.LimitPrice.ToString(format) : "");
			writer.WritePropertyName("OrderID");
			writer.WriteValue(request.OrderId > 0 ? request.OrderId.ToString() : "");
			writer.WritePropertyName("OrderType");
			writer.WriteValue(request.OrderType.ToString());
			writer.WritePropertyName("Quantity");
			writer.WriteValue(request.Quantity.ToString());
			writer.WritePropertyName("Route");
			writer.WriteValue(request.Route.ToString());
			writer.WritePropertyName("StopPrice");
			writer.WriteValue(request.StopPrice > 0 ? request.StopPrice.ToString(format) : "");
			writer.WritePropertyName("Symbol");
			writer.WriteValue(request.Symbol);
			writer.WritePropertyName("TradeAction");
			writer.WriteValue(request.TradeAction.ToString());
			writer.WriteEndObject();

		}
	}

	
	public class OrderDetailConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(OrderDetail).IsAssignableFrom(objectType);
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			OrderDetail order = new OrderDetail();
			while (reader.Read())
			{
				if (reader.Value != null)
				{
					int testInt;
					switch (reader.Value.ToString())
					{
						case "AccountAlias":
							if (reader.Read() && reader.Value != null) order.AccountAlias = reader.Value.ToString();
							break;
						case "AccountID":
							if (reader.Read() && reader.Value != null) order.AccountKey = reader.Value.ToString();
							break;
						case "AdvancedOptions":
							if (reader.Read() && reader.Value != null) order.AdvancedOptions = reader.Value.ToString();
							break;
						case "AssetType":
							AssetType assetType;
							if (reader.Read() && reader.Value != null && Enum.TryParse(reader.Value.ToString(), out assetType))
								order.AssetType = assetType;
							break;
						case "CommissionFee":
							if (reader.Read() && reader.Value != null) order.CommissionFee = decimal.Parse(reader.Value.ToString());
							break;
						case "ContractExpireDate":
							if (reader.Read() && reader.Value != null) order.ContractExpireDate = reader.Value.ToString();
							break;
						case "ConversionRate":
							decimal testDecimal;
							if (reader.Read() && reader.Value != null && decimal.TryParse(reader.Value.ToString(), out testDecimal)) order.ConversionRate = testDecimal;
							break;
						case "Country":
							if (reader.Read() && reader.Value != null && !string.IsNullOrEmpty(reader.Value.ToString()))
								order.Country = reader.Value.ToString();
							break;
						case "Denomination":
							Currency denomination;
							if (reader.Read() && reader.Value != null && Enum.TryParse(reader.Value.ToString(), out denomination))
								order.Denomination = denomination;
							break;
						case "Duration":
							if (reader.Read() && reader.Value != null && !string.IsNullOrEmpty(reader.Value.ToString()))
								order.Duration = new OrderDuration(reader.Value.ToString());
							break;
						case "ExecuteQuantity":
							if (reader.Read() && reader.Value != null && int.TryParse(reader.Value.ToString(), out testInt))
								order.ExecuteQuantity = testInt;
							break;
						case "FilledCanceled":
							if (reader.Read() && reader.Value != null) order.FilledCanceled = reader.Value.ToString();
							break;
						case "FilledPriceText":
							if (reader.Read() && reader.Value != null) order.FilledPriceText = reader.Value.ToString();
							break;
						case "GroupName":
							if (reader.Read() && reader.Value != null) order.GroupName = reader.Value.ToString();
							break;
						case "Legs":

							if (reader.Read() && reader.TokenType == JsonToken.StartArray)
							{
								//	order.Legs.AddRange((List<Leg>)JsonConvert.DeserializeObject<List<Leg>>(reader.Value.ToString()));
								StringWriter sw = new StringWriter();

								JsonTextWriter jw = new JsonTextWriter(sw);
								jw.WriteStartArray();

								do
								{
									reader.Read();
									jw.WriteToken(reader);
								} while (reader.TokenType != JsonToken.EndArray);
								order.Legs.AddRange(JsonConvert.DeserializeObject<List<Leg>>(sw.ToString()));
							}
							break;
						case "LimitPriceText":
							if (reader.Read() && reader.Value != null) order.LimitPriceText = reader.Value.ToString();
							break;
						case "OrderID":
							if (reader.Read() && reader.Value != null && int.TryParse(reader.Value.ToString(), out testInt))
								order.OrderId = testInt;
							break;
						case "Originator":
							if (reader.Read() && reader.Value != null && int.TryParse(reader.Value.ToString(), out testInt))
								order.Originator = testInt;
							break;
						case "Quantity":
							if (reader.Read() && reader.Value != null && int.TryParse(reader.Value.ToString(), out testInt))
								order.Quantity = testInt;
							break;
						case "QuantityLeft":
							if (reader.Read() && reader.Value != null && int.TryParse(reader.Value.ToString(), out testInt))
								order.QuantityLeft = testInt;
							break;
						case "RejectReason":
							if (reader.Read() && reader.Value != null) order.RejectReason = reader.Value.ToString();
							break;
						case "Routing":
							Route route;
							if (reader.Read() && reader.Value != null && Enum.TryParse(reader.Value.ToString(), out route))
								order.Route = route;
							break;
						case "Spread":
							if (reader.Read() && reader.Value != null) order.Spread = reader.Value.ToString();
							break;
						case "Status":
							if (reader.Read() && reader.Value != null) order.Status = (OrderState)Enum.Parse(typeof(OrderState), reader.Value.ToString());
							break;
						case "StatusDescription":
							if (reader.Read() && reader.Value != null) order.StatusDescription = reader.Value.ToString();
							break;
						case "StopPriceText":
							if (reader.Read() && reader.Value != null) order.StopPriceText = reader.Value.ToString();
							break;
						case "Symbol":
							if (reader.Read() && reader.Value != null) order.Symbol = reader.Value.ToString();
							break;
						case "TimeStamp":
							if (reader.Read() && reader.Value != null) order.TimeStamp = DateTime.Parse(reader.Value.ToString());
							break;
						case "TriggeredBy":
							if (reader.Read() && reader.Value != null) order.TriggeredBy = reader.Value.ToString();
							break;
						case "Type":
							if (reader.Read() && reader.Value != null)
							{
								StringBuilder action = new StringBuilder(255);
								string[] fields = reader.Value.ToString().Split(' ');
								foreach (string field in fields)
								{
									if (!string.IsNullOrEmpty(field)) action.Append(Char.ToUpper(field[0]) + field.Substring(1).ToLower());
								}
								order.TradeAction = (TradeAction)Enum.Parse(typeof(TradeAction), action.ToString());
							}
								
							break;
						default:
							reader.Read();
							break;

					}
				}
				else
					break;
			}

			return order;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();

			//Order order = value as Order;
			//if (order == null) throw new ArgumentException("Invalid Order, cannot write Json", "value");

			//string format = null;
			//switch (request.AssetType)
			//{
			//    case AssetType.FX:
			//        format = request.Symbol.ToUpper().Trim() == "USDJPY" ? "0.000" : "0.00000";
			//        break;
			//    default:
			//        format = "0.00";
			//        break;
			//}

			//writer.WriteStartObject();
			//writer.WritePropertyName("AccountKey");
			//writer.WriteValue(request.AccountKey);
			//writer.WritePropertyName("AssetType");
			//writer.WriteValue(request.AssetType.ToString());
			//writer.WritePropertyName("Duration");
			//writer.WriteValue(request.Duration.ToString());
			//writer.WritePropertyName("GTDDate");
			//writer.WriteValue(request.GTDDate > DateTime.MinValue ? request.GTDDate.ToShortDateString() : "");
			//writer.WritePropertyName("LimitPrice");
			//writer.WriteValue(request.LimitPrice > 0 ? request.LimitPrice.ToString(format) : "");
			//writer.WritePropertyName("OrderID");
			//writer.WriteValue(request.OrderId > 0 ? request.OrderId.ToString() : "");
			//writer.WritePropertyName("OrderType");
			//writer.WriteValue(request.OrderType.ToString());
			//writer.WritePropertyName("Quantity");
			//writer.WriteValue(request.Quantity.ToString());
			//writer.WritePropertyName("Route");
			//writer.WriteValue(request.Route.ToString());
			//writer.WritePropertyName("StopPrice");
			//writer.WriteValue(request.StopPrice > 0 ? request.StopPrice.ToString(format) : "");
			//writer.WritePropertyName("Symbol");
			//writer.WriteValue(request.Symbol);
			//writer.WritePropertyName("TradeAction");
			//writer.WriteValue(request.TradeAction.ToString());
			//writer.WriteEndObject();
			/*
			 "AccountAlias": "FX543857 QA",
	"AccountID": "FX543857 QA",
	"AdvancedOptions": "",
	"AssetType": "FX",
	"CommissionFee": 0.0000,
	"ContractExpireDate": "",
	"ConversionRate": 0.0121387213,
	"Country": null,
	"Denomination": "JPY",
	"Duration": "GTC - 5\/23\/2012",
	"ExecuteQuantity": 0,
	"FilledCanceled": "",
	"FilledPriceText": "0.0000000000",
	"GroupName": "",
	"Legs": [
	  {
		"Ask": 81.5760000000,
		"BaseSymbol": "",
		"Bid": 81.5240000000,
		"ExecPrice": 0.0000000000,
		"ExecQuantity": 0,
		"ExpireDate": "",
		"Leaves": 1,
		"LegNumber": 1,
		"LimitPrice": 72.0730000000,
		"LimitPriceDisplay": "72.0730000000",
		"Month": 0,
		"OpenOrClose": "",
		"OrderID": 208033109,
		"OrderType": "Limit",
		"PointValue": 1.0000000000,
		"PriceUsedForBuyingPower": 72.0730000000,
		"PutOrCall": "",
		"Quantity": 10001,
		"Side": "B",
		"StopPrice": 0,
		"StopPriceDisplay": "0",
		"StrikePrice": 0,
		"Symbol": "USDJPY",
		"TimeExecuted": "1\/1\/0001 12:00:00 AM",
		"Year": 0
	  }
	],
	"LimitPriceText": "72.0730000000",
	"OrderID": 208033109,
	"Originator": 543857,
	"Quantity": 10001,
	"QuantityLeft": 10001,
	"RejectReason": "",
	"Routing": "",
	"Spread": "",
	"Status": "ACK",
	"StatusDescription": "Received",
	"StopPriceText": "0",
	"Symbol": "USDJPY",
	"TimeStamp": "2\/23\/2012 6:41:39 PM",
	"TriggeredBy": "",
	"Type": "Buy"
			 */
		}
	}

	

}
