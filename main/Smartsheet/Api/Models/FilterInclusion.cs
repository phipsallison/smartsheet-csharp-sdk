﻿//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents filter inclusion
	/// </summary>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum FilterInclusion
	{
		/// <summary>
		/// Response will include the filter that the user has applied to each column (if any).
		/// </summary>
		[EnumMember(Value = "filters")]
		FILTERS
	}

}