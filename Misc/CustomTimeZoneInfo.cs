/*
 * Exchange Web Services Managed API
 *
 * Copyright (c) Microsoft Corporation
 * All rights reserved.
 *
 * MIT License
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge,
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 * to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Exchange.WebServices.Data.Misc
{
    public class CustomTimeZoneInfo
    {
        private AdjustmentRule[] adjustmentRules;
        public string Id { get; private set; }
        public TimeSpan BaseUtcOffset { get; private set; }
        public string DisplayName { get; private set; }
        public string StandardName { get; private set; }
        public string DaylightName { get; private set; }
        public bool SupportsDaylightSavingTime { get; private set; }
        public AdjustmentRule[] GetAdjustmentRules()
        {
            return adjustmentRules;
        }
        public bool Equals(TimeZoneInfo timeZoneInfo)
        {
            if (this.Id != timeZoneInfo.Id)
            {
                return false;
            }

            // NOTE: skipping comparison of adjustment rules since TimeZoneInfo doesn't have adjustment rules
            return true;
        }
        
        public static CustomTimeZoneInfo CreateCustomTimeZone(
            string id,
            TimeSpan baseUtcOffset,
            string displayName,
            string standardDisplayName)
        {
            CustomTimeZoneInfo customTimeZoneInfo = new CustomTimeZoneInfo();
            customTimeZoneInfo.Id = id;
            customTimeZoneInfo.BaseUtcOffset = baseUtcOffset;
            customTimeZoneInfo.DisplayName = displayName;
            customTimeZoneInfo.StandardName = standardDisplayName;
            customTimeZoneInfo.SupportsDaylightSavingTime = false;
            return customTimeZoneInfo;
        }

        public static CustomTimeZoneInfo CreateCustomTimeZone(
            string id,
            TimeSpan baseUtcOffset,
            string displayName,
            string standardDisplayName,
            string daylightDisplayName,
            AdjustmentRule[] adjustmentRules
        )
        {
            CustomTimeZoneInfo customTimeZoneInfo = new CustomTimeZoneInfo();
            customTimeZoneInfo.Id = id;
            customTimeZoneInfo.BaseUtcOffset = baseUtcOffset;
            customTimeZoneInfo.DisplayName = displayName;
            customTimeZoneInfo.StandardName = standardDisplayName;
            customTimeZoneInfo.DaylightName = daylightDisplayName;
            customTimeZoneInfo.SupportsDaylightSavingTime = adjustmentRules.Length > 0 ? true : false;
            customTimeZoneInfo.adjustmentRules = adjustmentRules;
            return customTimeZoneInfo;
        }

        public static CustomTimeZoneInfo CreateCustomTimeZone(
            TimeZoneInfo timeZoneInfo
        )
        {
            CustomTimeZoneInfo customTimeZoneInfo = new CustomTimeZoneInfo();
            customTimeZoneInfo.Id = timeZoneInfo.Id;
            customTimeZoneInfo.BaseUtcOffset = timeZoneInfo.BaseUtcOffset;
            customTimeZoneInfo.DisplayName = timeZoneInfo.DisplayName;
            customTimeZoneInfo.StandardName = timeZoneInfo.StandardName;
            customTimeZoneInfo.DaylightName = timeZoneInfo.DaylightName;
            customTimeZoneInfo.SupportsDaylightSavingTime = timeZoneInfo.SupportsDaylightSavingTime;
            // NOTE: Time Zone Info doesn't support adjustment rules
            // customTimeZoneInfo.adjustmentRules = timeZoneInfo.getAdjustRules();
            return customTimeZoneInfo;
        }
    }
}
