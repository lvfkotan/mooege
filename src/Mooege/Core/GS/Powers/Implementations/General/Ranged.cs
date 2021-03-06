﻿/*
 * Copyright (C) 2011 mooege project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mooege.Core.GS.Skills;
using Mooege.Core.GS.Ticker;
using Mooege.Core.GS.Actors;

namespace Mooege.Core.GS.Powers.Implementations
{
    [ImplementsPowerSNO(30334)]  // Monster_Ranged_Projectile.pow
    public class MonsterRangedProjectile : ActionTimedSkill
    {
        public override IEnumerable<TickTimer> Main()
        {
            var proj = new Projectile(this, 3901, User.Position);
            proj.OnCollision = (hit) =>
            {
                WeaponDamage(hit, 1.00f, DamageType.Physical);
                proj.Destroy();
            };
            proj.Launch(TargetPosition, 1f);

            yield break;
        }
    }

    [ImplementsPowerSNO(30503)]  // SkeletonSummoner_Projectile.pow
    public class SkeletonSummonerProjectile : ActionTimedSkill
    {
        public override IEnumerable<TickTimer> Main()
        {
            var proj = new Projectile(this, 5392, User.Position);
            proj.Position.Z += 5f; // fix height
            proj.OnCollision = (hit) =>
            {
                hit.PlayEffectGroup(19052);
                WeaponDamage(hit, 2.00f, DamageType.Arcane);
                proj.Destroy();
            };
            proj.Launch(TargetPosition, 0.5f);

            yield break;
        }
    }
}
