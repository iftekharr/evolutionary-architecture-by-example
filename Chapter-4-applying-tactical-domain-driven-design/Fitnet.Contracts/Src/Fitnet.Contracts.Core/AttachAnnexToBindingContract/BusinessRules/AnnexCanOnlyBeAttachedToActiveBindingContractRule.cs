﻿namespace EvolutionaryArchitecture.Fitnet.Contracts.Core.AttachAnnexToBindingContract.BusinessRules;

using EvolutionaryArchitecture.Fitnet.Common.Core.BusinessRules;

internal sealed class AnnexCanOnlyBeAttachedToActiveBindingContractRule : IBusinessRule
{
    private readonly DateTimeOffset? _bindingContractTerminatedAt;
    private readonly DateTimeOffset _bindingContractExpiringAt;
    private readonly DateTimeOffset _now;

    internal AnnexCanOnlyBeAttachedToActiveBindingContractRule(
        DateTimeOffset? bindingContractTerminatedAt,
        DateTimeOffset bindingContractExpiringAt,
        DateTimeOffset now)
    {
        _bindingContractTerminatedAt = bindingContractTerminatedAt;
        _bindingContractExpiringAt = bindingContractExpiringAt;
        _now = now;
    }

    public bool IsMet() => !_bindingContractTerminatedAt.HasValue && _bindingContractExpiringAt > _now;

    public string Error => "Annex can only be attached to active binding contract";
}