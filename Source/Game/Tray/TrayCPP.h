﻿#pragma once

#include "Engine/Scripting/Script.h"

API_CLASS() class GAME_API TrayCPP : public Script
{
API_AUTO_SERIALIZATION();
DECLARE_SCRIPTING_TYPE(TrayCPP);

    // [Script]
    void OnEnable() override;
    void OnDisable() override;
    void OnUpdate() override;
};
