# Secure Socket Communication

A secure client–server socket communication system implemented in C#,
featuring a custom Certificate Authority (CA), certificate-based authentication,
encrypted messaging, and centralized user discovery.

## Overview
This project demonstrates a complete secure communication workflow over TCP sockets.
Clients authenticate using certificates issued by a custom CA, establish a secure session
via RSA-based key exchange, and communicate using AES-encrypted messages.

<img width="1919" height="748" alt="image" src="https://github.com/user-attachments/assets/f7b141b0-173b-46c6-87cd-b595e2d979c5" />

## Technologies
- C#
- .NET
- TCP / UDP Sockets
- RSA & AES Cryptography
- JSON-based message protocol
  
## Key Features
- TCP-based client–server communication
- Custom Certificate Authority (CA) for identity verification
- RSA-based authentication and secure key exchange
- AES-encrypted session communication
- Centralized directory service for secure client discovery
- Real-time encrypted messaging

## Architecture
- The CA server issues and signs client certificates
- Clients register their network endpoints with the CA
- A centralized directory service enables secure user discovery
- Peer-to-peer communication is established only after authentication
- Session keys are generated dynamically for encrypted communication

## Usage
1. Start the Certificate Authority server.
2. Launch client applications and discover the CA via UDP broadcast.
3. Request and verify certificates from the CA.
4. Register clients in the directory service.
5. Establish a secure session and exchange encrypted messages.

## Empty Version

<img width="2400" height="600" alt="image" src="https://github.com/user-attachments/assets/7b1f230b-9ba8-48e8-ac5f-94b74d94aed1" /> <img width="400" height="600" alt="image" src="https://github.com/user-attachments/assets/aa7cbced-0938-4614-b9df-24cf18ef9e28" />
