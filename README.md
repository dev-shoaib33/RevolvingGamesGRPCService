# Documentation of Development Process and Code Evolution

## Initial Development:
To fulfill the requirements outlined in the task, the following steps were taken:

1. A client-server architecture was implemented using gRPC.
2. The client was designed to send 10,000 requests per second, each containing a randomly generated number between 1 and 1000.
3. On the server side, the incoming requests were processed to determine whether the sent number is prime or not.
4. The server responded to each request based on the primality of the number.
5. The server kept track of all valid prime numbers and maintained a list of the top 10 highest requested/validated prime numbers.

## Code Evolution:
During the development process, several iterations were performed to enhance functionality, improve performance, and ensure reliability. The following highlights key milestones and code improvements:

### 2.1. Initial Implementation:
- The initial implementation established the client-server communication, generated random numbers, and verified primality on the server side.
- The server maintained a simple list of prime numbers and tracked the counts of each requested/validated prime number.

### 2.2. Response Verification:
- A response verification mechanism was added on the client side to ensure that all 10,000 responses were received.
- Proper actions were implemented to handle missing responses, such as error reporting.

### 2.3. RTT Measurement:
- To measure the Round Trip Time (RTT) for each sent message on the client side, a timing mechanism using the Stopwatch class was integrated into the code.
- The Stopwatch class was used to record the elapsed time from sending a request to receiving a response.
- The RTT values were logged or displayed for analysis and monitoring purposes.
  
### 2.4. Enhanced Server Statistics:
- The server-side code was improved to keep track of highest 10 valid prime numbers requested and validated.
- The top 10 highest requested/validated prime numbers were updated dynamically and displayed every second.

## Testing and Optimization:
Throughout the development process, extensive testing and optimization were conducted to ensure the system's performance, reliability, and scalability. 

## Conclusion:
The development process involved designing a client-server system capable of handling 10,000 requests per second, verifying primality, tracking prime numbers, and monitoring statistics. The code evolved through multiple iterations, incorporating response verification, RTT measurement, and enhanced server statistics. Rigorous testing and optimization were conducted to deliver a high-performing and reliable solution.

By adhering to best practices, employing suitable data structures, and ensuring code quality, the system successfully accomplished the outlined requirements. It provides accurate primality verification, tracks prime numbers, displays statistics, and handles high request volumes efficiently.
