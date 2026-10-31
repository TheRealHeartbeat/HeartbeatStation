// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Server.Cargo.Systems;
using Content.Server.GameTicking;
using Content.Shared.Cargo.Components;
using Content.Shared._Trauma.Antag;

namespace Content.Server._Trauma.Antag;

public sealed class AntagSummonerSystem : SharedAntagSummonerSystem
{
    [Dependency] private readonly CargoSystem _cargo = default!;
    [Dependency] private readonly GameTicker _ticker = default!;

    protected override void SummonAntag(Entity<AntagSummonerComponent> ent, EntityUid station)
    {
        _ticker.StartGameRule(ent.Comp.GameRule);
        if (TryComp<StationBankAccountComponent>(station, out var bankAccount))
            _cargo.UpdateBankAccount((station, bankAccount), ent.Comp.Reward, ent.Comp.Account);
    }
}
