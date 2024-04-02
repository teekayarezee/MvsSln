﻿/*!
 * Copyright (c) 2013  Denis Kuzmin <x-3F@outlook.com> github/3F
 * Copyright (c) MvsSln contributors https://github.com/3F/MvsSln/graphs/contributors
 * Licensed under the MIT License (MIT).
 * See accompanying License.txt file or visit https://github.com/3F/MvsSln
*/

using System;
using System.Collections.Generic;
using net.r_eg.MvsSln.Extensions;

namespace net.r_eg.MvsSln.Core.ObjHandlers
{
    public class WSolutionConfigurationPlatforms: WAbstract, IObjHandler
    {
        /// <summary>
        /// Solution configurations with platforms.
        /// </summary>
        protected IEnumerable<IConfPlatform> configs;

        public override string Extract(object data)
        {
            lbuilder.Clear();

            lbuilder.AppendLv1Line("GlobalSection(SolutionConfigurationPlatforms) = preSolution");

            configs.ForEach(cfg => lbuilder.AppendLv2Line($"{cfg} = {cfg}"));

            return lbuilder.AppendLv1("EndGlobalSection").ToString();
        }

        /// <param name="configs">Solution configurations with platforms.</param>
        public WSolutionConfigurationPlatforms(IEnumerable<IConfPlatform> configs)
        {
            this.configs = configs ?? throw new ArgumentNullException(nameof(configs));
        }
    }
}
