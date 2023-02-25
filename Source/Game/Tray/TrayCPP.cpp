#include "TrayCPP.h"

TrayCPP::TrayCPP(const SpawnParams& params)
    : Script(params)
{
    // Enable ticking OnUpdate function
    _tickUpdate = true;
}

void TrayCPP::OnEnable()
{
    // Here you can add code that needs to be called when script is enabled (eg. register for events)
}   

void TrayCPP::OnDisable()
{
    // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
}

void TrayCPP::OnUpdate()
{
    // Here you can add code that needs to be called every frame
}
