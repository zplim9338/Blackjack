# Blackjack

A simple Blackjack game written in C# using WPF. This implementation supports one dealer and one player. Graphics are not necessary, and the game displays the players' hands using text.

## Features

- Graphics are not necessary
- Supports at least a dealer and one player
- Displays players’ hands in text format
- Correctly deals cards and keeps track of the remaining cards in the deck (or decks)

## Game Rules

1. **Objective:** Score higher than the Dealer’s hand without exceeding twenty-one.
2. **Card Values:**
    - Number cards (2-10) count as their face value.
    - Face cards (Jack, Queen, King) count as ten.
    - Aces count as either one or eleven, whichever benefits the player.
3. **Scoring:**
    - Beat the Dealer: +10 points
    - Get Blackjack (21 with just two cards) and beat the Dealer: +15 points
    - Player loses by exceeding 21: -10 points
    - Push (tie with Dealer): No points added or subtracted

## Gameplay

1. **Initial Deal:**
    - The Dealer and the Player each receive two cards from a standard 52-card deck.
    - One of the Dealer's cards is dealt face down.
2. **Player's Turn:**
    - The Player can choose to "Hit" (get another card) or "Stay" (keep current hand).
    - The Player can continue to hit as many times as desired.
    - If the Player's total exceeds 21 before staying, the Player loses.
3. **Dealer's Turn:**
    - The Dealer adds cards until the total exceeds 16.
    - If the Dealer exceeds 21 or has a total less than the Player's, the Dealer loses.
    - If the Dealer's total is greater than the Player's total (and under 21), the Dealer wins.
    - If the Dealer and Player have the same total, it is a Push.
4. **Reshuffling:**
    - The cards are reshuffled whenever there are fewer than fifteen cards remaining in the deck.
