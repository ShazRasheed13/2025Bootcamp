Thread safety in Banking problem explained.

MUTABLE APPROACH (DANGEROUS!)
Time: 9:00:00 AM
ACCOUNT LEDGER
+------------------------+
|  Account: #12345       |
|  Balance: $1000       ←---- Both Alice and Bob read this same balance
|  Last Updated: 9:00 AM |
+------------------------+

Time: 9:00:01 AM
Alice's Phone                     Bob's Phone
+------------------+             +------------------+
| Checking Balance  |            | Checking Balance  |
| $1000 Available  |            | $1000 Available  |
| Withdraw: $800   |            | Withdraw: $700   |
| "Looks good!"    |            | "Looks good!"    |
+------------------+             +------------------+

Time: 9:00:02 AM
ACCOUNT LEDGER
+------------------------+
|  Account: #12345       |
|  Balance: $200        ←---- Alice updates (1000 - 800)
|  Last Updated: 9:00 AM |
+------------------------+

Time: 9:00:03 AM
ACCOUNT LEDGER
+------------------------+
|  Account: #12345       |
|  Balance: -$500       ←---- Bob updates (200 - 700) PROBLEM!
|  Last Updated: 9:00 AM |
+------------------------+


IMMUTABLE APPROACH (SAFE!)
Original Account State
+------------------------+
|  Statement #1001       |
|  Balance: $1000        |
|  Time: 9:00:00 AM     |
+------------------------+
        ↓
Alice's Transaction Request    Bob's Transaction Request
+------------------------+    +------------------------+
|  Check #A001          |    |  Check #B001          |
|  Based on: #1001      |    |  Based on: #1001      |
|  Current: $1000       |    |  Current: $1000       |
|  Withdraw: $800       |    |  Withdraw: $700       |
|  Time: 9:00:01 AM     |    |  Time: 9:00:01 AM     |
+------------------------+    +------------------------+

Bank Processing Queue
+------------------------------------------------+
|  1. Process Check #A001 (Alice)                 |
|     → Verify Statement #1001 ($1000)           |
|     → Approve $800 withdrawal                   |
|     → Create new Statement #1002 ($200)         |
|                                                 |
|  2. Process Check #B001 (Bob)                   |
|     → Verify Statement #1002 ($200)            |
|     → Reject $700 withdrawal (insufficient)     |
+------------------------------------------------+

Final States
Statement #1001 (Original)    Statement #1002 (After Alice)
+------------------------+    +------------------------+
|  Balance: $1000        |    |  Balance: $200        |
|  Time: 9:00:00 AM     |    |  Time: 9:00:02 AM     |
|  Status: Archived      |    |  Status: Current      |
+------------------------+    +------------------------+

Transaction Results
Alice's Receipt                Bob's Receipt
+------------------------+    +------------------------+
|  Transaction #A001     |    |  Transaction #B001     |
|  Amount: $800         |    |  Amount: $700         |
|  Status: APPROVED     |    |  Status: REJECTED     |
|  New Balance: $200    |    |  Reason: Insufficient  |
+------------------------+    +------------------------+
