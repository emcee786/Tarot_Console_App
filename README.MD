Tarot Card Reader

A simple C# console application built while learning the language. The program fetches tarot card data from TarotAPI, shuffles a virtual deck, and displays upright or reversed meanings for drawn cards.
✨ Features

    Fetches card data dynamically from TarotAPI

    Shuffles a virtual tarot deck

    Draws one or more cards

    Displays upright or reversed card meanings

    Demonstrates async/await, HttpClient, JSON deserialization, and OOP in C#

🛠 Prerequisites

    .NET 6 or later installed


🚀 How to Run

    Clone the repository:

git clone https://github.com/your-username/tarot-card-reader.git
cd tarot-card-reader

Build the project:

dotnet build

Run the program:

    dotnet run

📂 Project Structure

TarotCardReader/
│
├── Program.cs          # Entry point of the app
├── Deck.cs             # Manages the deck, shuffling, and drawing cards
├── Card.cs             # Represents an individual tarot card
├── API.cs              # DTO classes for parsing TarotAPI responses
└── README.md

🎯 Purpose

This project was built as a learning exercise while exploring C#. It focuses on understanding asynchronous programming, API calls, and object-oriented design.