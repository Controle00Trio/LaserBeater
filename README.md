# Hyper-Casual Core Loop Prototype

## Unity Version
Unity 6000.3.0f1

## Overview
This project is a hyper-casual prototype focused on a simple, input-driven core loop.
The goal is to test moment-to-moment responsiveness, obstacle pacing, and lightweight
economy integration suitable for short play sessions.



## Core Loop
The core gameplay loop is built around a single input mechanic:

- Holding input causes the character to move forward
- Releasing input immediately stops movement
- The player must time movement precisely to avoid laser obstacles
- Distance traveled determines the final score

The challenge comes from reacting to obstacle patterns and deciding when to move or stop.
Each run ends on collision, encouraging short, repeatable play sessions.



## Architecture Overview
The project follows a modular, manager-based architecture:

- Separate managers handle UI, scoring, store, and gameplay systems
- A central GameManager coordinates game state and event flow
- Systems communicate through events rather than direct references where possible

This approach was chosen to keep systems loosely coupled, making future iteration
and feature expansion easier.



## Performance Strategy
Performance was prioritized to ensure smooth gameplay on low-end devices:

- Object pooling is used for level tiles to avoid runtime instantiation costs
- Tiles are reused on reset instead of being destroyed and recreated
- UI value updates are limited to change-only events instead of per-frame updates

These decisions reduce garbage collection spikes and unnecessary CPU usage during gameplay.



## IAP & Economy Design
The economy is designed to support both progression and monetization:

- Soft currency is rewarded based on the distance traveled in each run
- Premium currency is obtained through in-app purchases
- Cosmetic or gameplay-related items can be purchased using either soft or premium currency,
  depending on item type and rarity

This structure allows flexible reward tuning while maintaining clear player incentives.



## Known Limitations & Future Improvements
- Player movement responsiveness can be further improved
- Purchasable item effects are not yet implemented
- Additional feedback (VFX, audio cues) could enhance moment-to-moment gameplay

These areas were deprioritized to focus on validating the core loop and system structure first.
