﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Graphics;
using osu.Game.Overlays.Profile.Sections;
using osu.Game.Overlays.Profile.Sections.Historical;
using osu.Game.Users;

namespace osu.Game.Tests.Visual
{
    internal class TestCaseHistoricalSection : OsuTestCase
    {
        public override string Description => "User's History";

        public override IReadOnlyList<Type> RequiredTypes => new [] { typeof(HistoricalSection), typeof(PaginatedMostPlayedBeatmapContainer), typeof(MostPlayedBeatmapDrawable) };


        public TestCaseHistoricalSection()
        {
            HistoricalSection section;

            Add(new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = OsuColour.Gray(0.2f)
            });

            Add(new ScrollContainer
            {
                RelativeSizeAxes = Axes.Both,
                Child = section = new HistoricalSection(),
            });

            AddStep("Show peppy", () => section.User.Value = new User { Id = 2 });
            AddStep("Show WubWoofWolf", () => section.User.Value = new User { Id = 39828 });
        }
    }
}
