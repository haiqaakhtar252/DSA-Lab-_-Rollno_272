# Data Structures & Algorithms — ASP.NET Core Web API Lab Solution

### Student Details
- **Student Name:** Haiqa Akhtar
- **Registration Number:** 2025-SE-272
- **Course:** Data Structures & Algorithms (DSA)
- **Framework:** .NET 9.0 ASP.NET Core Web API
- **Solution:** `DSALabs.sln`

---

## 📁 Repository & Solution Architecture

The solution `DSALabs.sln` aggregates three distinct, strictly structured ASP.NET Core Web API projects:

```text
DSALabs/
├── .gitignore                          ← Standard .NET gitignore + *.docx, ~$*
├── DSALabs.sln                         ← Root Solution aggregating all 3 Web API projects
├── README.md                           ← Project Documentation & Theory Notes
│
├── DSALabsWeek01Api/                   ← Project 1: Lab 0 (Intro to DSA & Big-O Analysis)
│   ├── DSALabsWeek01Api.csproj
│   ├── Program.cs
│   ├── Models/
│   │   └── Dtos.cs                     ← ApiResponse<T>, Request DTOs
│   ├── Services/
│   │   ├── FactorialService.cs         ← Iterative O(n) & Recursive O(n) using BigInteger
│   │   ├── MultiplicationService.cs    ← Traditional O(n²) & Karatsuba O(n^1.585)
│   │   ├── TimingService.cs            ← Benchmark generator for 10, 50, 100, 500, 1000 digits
│   │   └── BigOAnalysisService.cs      ← Theoretical complexity report & concrete comparisons
│   └── Controllers/
│       ├── SetupController.cs          ← Task 1: Environment verification (Haiqa Akhtar, 2025-SE-272)
│       ├── FactorialController.cs      ← Task 2: Iterative, recursive, & side-by-side compare
│       ├── MultiplicationController.cs ← Tasks 3 & 4: Traditional, Karatsuba, & compare
│       ├── ComplexityController.cs     ← Tasks 5 & 6: Benchmark & theoretical Big-O analysis
│       ├── ReflectionController.cs     ← Task 7: Exact reflection answers
│       └── LeetCodeController.cs       ← Bonus: Reverse Int, Palindrome, Pow, Fib, Trailing Zeros
│
├── ArrayLabApi/                        ← Project 2: Lab 1 (Fixed-Size Array Operations)
│   ├── ArrayLabApi.csproj
│   ├── Program.cs                      ← Singleton registrations (Capacity 15 & 20)
│   ├── Models/
│   │   └── Dtos.cs                     ← Request & Student DTO models
│   ├── Services/
│   │   ├── ArrayOperations.cs          ← Fixed-capacity (15) array CRUD (Tasks 01–04)
│   │   └── StudentManager.cs           ← Fixed-capacity (20) student roll manager (Task 05)
│   └── Controllers/
│       ├── ArrayController.cs          ← Endpoints for traverse, insert, delete, search, update
│       └── StudentsController.cs       ← Student CRUD and POST /api/students/demo
│
└── LinkedListLabApi/                   ← Project 3: Lab 3 (Linked List Implementations)
    ├── LinkedListLabApi.csproj
    ├── Program.cs                      ← Singleton registrations for all 3 Linked Lists
    ├── Models/
    │   └── Dtos.cs                     ← Generic ApiResponse<T> & node operation DTOs
    ├── Services/
    │   ├── SinglyLinkedList.cs         ← Singly Linked List CRUD with Big-O docstrings
    │   ├── DoublyLinkedList.cs         ← Doubly Linked List with head & tail pointers
    │   └── CircularLinkedList.cs       ← Circular Singly Linked List with loop prevention
    └── Controllers/
        ├── SinglyLinkedListController.cs   ← Singly list endpoints & 10-step demo
        ├── DoublyLinkedListController.cs   ← Doubly list forward/backward traversal & CRUD
        └── CircularLinkedListController.cs ← Circular list loop-safe traversal & CRUD
```

---

## 🚀 Getting Started & Execution Guide

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) or higher

### Build Verification
To restore dependencies and build the entire solution:
```bash
dotnet build DSALabs.sln
```

### Running the API Projects & Swagger UI

Each API project runs on its own local port and features an interactive Swagger UI documentation dashboard.

#### 1. Running Project 1 (`DSALabsWeek01Api`):
```bash
cd DSALabsWeek01Api
dotnet run
```
Open your browser at:
- `http://localhost:<port>/swagger` (or `https://localhost:<https-port>/swagger`)

#### 2. Running Project 2 (`ArrayLabApi`):
```bash
cd ArrayLabApi
dotnet run
```
Open your browser at:
- `http://localhost:<port>/swagger` (or `https://localhost:<https-port>/swagger`)

#### 3. Running Project 3 (`LinkedListLabApi`):
```bash
cd LinkedListLabApi
dotnet run
```
Open your browser at:
- `http://localhost:<port>/swagger` (or `https://localhost:<https-port>/swagger`)

---

## 📊 Theoretical Analysis & Complexity Tables

*(Extracted directly from `Lab1-Lab2-Theory.docx` and `Lab03-LinkedLists.docx`)*

### 1. Array Operations Complexity

| Operation | Time Complexity | Space Complexity | Why / Notes |
| :--- | :--- | :--- | :--- |
| **Traverse** | $O(n)$ | $O(1)$ | Must visit all $n$ elements |
| **Access by index** | $O(1)$ | $O(1)$ | Direct memory address calculation |
| **Insert at end** | $O(1)$ amortized | $O(1)$ | Direct index write at `_size++` if space available |
| **Insert at beginning** | $O(n)$ | $O(1)$ | Every element must shift one slot right |
| **Insert at position** | $O(n)$ | $O(1)$ | Shift elements from `pos` onward to the right |
| **Delete from end** | $O(1)$ | $O(1)$ | Just decrement `_size--` |
| **Delete from beginning** | $O(n)$ | $O(1)$ | Every element shifts left |
| **Delete at position** | $O(n)$ | $O(1)$ | Shift elements after `pos` one slot left |
| **Update at position** | $O(1)$ | $O(1)$ | Direct index overwrite |
| **Linear Search** | $O(n)$ | $O(1)$ | Worst case scans all $n$ elements |
| **Search All Occurrences**| $O(n)$ | $O(k)$ | Scans all elements, returns list of matching indices |
| **Snapshot** | $O(n)$ | $O(n)$ | Copies `_size` elements for encapsulation |

---

### 2. Big O Complexity Comparison

| Complexity | Growth Behavior | Evaluation |
| :--- | :--- | :--- |
| **$O(1)$** | Constant — same time regardless of input size | ✅ Optimal |
| **$O(\log n)$** | Logarithmic — grows very slowly | ✅ Highly Scalable |
| **$O(n)$** | Linear — time grows proportionally with input | ⚠️ Moderate |
| **$O(n \log n)$** | Linearithmic — standard for efficient sorting | ⚠️ Acceptable for large inputs |
| **$O(n^2)$** | Quadratic — time explodes with large inputs | ❌ Inefficient for large $n$ |

#### Practical Scaling Example: Bubble Sort vs. Quick Sort
| Algorithm | 10 Items | 1,000 Items | 1,000,000 Items |
| :--- | :--- | :--- | :--- |
| **Bubble Sort ($O(n^2)$)** | 0.001 s | 10 s | ~11 days |
| **Quick Sort ($O(n \log n)$)** | 0.002 s | 0.01 s | ~20 s |

---

### 3. Factorial: Iterative vs. Recursive

| Method | Time Complexity | Space Complexity | Practical Notes |
| :--- | :--- | :--- | :--- |
| **Iterative** | $O(n)$ | $O(1)$ | Single loop variable, no stack overflow danger |
| **Recursive** | $O(n)$ | $O(n)$ | Call stack grows linearly with $n$; risks stack overflow for large $n$ |

*Note: In `DSALabsWeek01Api`, both methods utilize `System.Numerics.BigInteger` to avoid integer overflow beyond $20!$.*

---

### 4. Large Number Multiplication: Traditional vs. Karatsuba

| Algorithm | Time Complexity | Space Complexity | Key Characteristics |
| :--- | :--- | :--- | :--- |
| **Traditional (Schoolbook)** | $O(n^2)$ | $O(1)$ auxiliary | Simple bit-shift/pairwise multiplies; faster for $n < 100$ digits due to low constant overhead. |
| **Karatsuba (Divide-and-Conquer)** | $O(n^{\log_2 3}) pprox O(n^{1.585})$ | $O(n)$ recursion stack | Splits operands into high/low halves; uses 3 recursive multiplications instead of 4; dominates asymptotically for large $n$. |

---

### 5. Summary Topic Comparison Matrix

| Topic | Homogeneous? | Best Time | Worst Time | Space | Key Strength | Key Weakness |
| :--- | :---: | :---: | :---: | :---: | :--- | :--- |
| **Array** | ✅ Yes | $O(1)$ access | $O(n)$ shift | $O(n)$ | Instant random access | Fixed capacity, costly shifts |
| **Complexity Analysis**| N/A | — | — | — | Predicts scalability | Ignores hardware constants |
| **Factorial (Iterative)**| N/A | $O(n)$ | $O(n)$ | $O(1)$ | Memory efficient, no recursion | Arithmetic overflow if not BigInt |
| **Factorial (Recursive)**| N/A | $O(n)$ | $O(n)$ | $O(n)$ | Mirrors math definition | Call stack overhead & overflow |
| **Multiplication (Traditional)**| N/A | $O(n^2)$ | $O(n^2)$ | $O(1)$ | Simplicity, low overhead | Impractical for huge numbers |
| **Multiplication (Karatsuba)**| N/A | $O(n^{1.585})$ | $O(n^{1.585})$ | $O(n)$ | Sub-quadratic scaling | Implementation complexity |
| **Reflection** | N/A | $O(1)$ | $O(n)$ | $O(	ext{types})$ | Runtime inspection & DI | Performance cost, loses type safety |
| **Students (CRUD)** | Mixed | $O(1)$ add | $O(n)$ search | $O(n)$ | Full entity lifecycle | Linear scan without hash indexing |
| **Schemas (DTOs)** | N/A | $O(n)$ | $O(n)$ | $O(n)$ | Type safety & Swagger docs | Serialization boilerplate |

---

### 6. Linked Lists Operations & Complexity (From `Lab03-LinkedLists.docx`)

#### Singly Linked List (SLL)
| Operation | Time Complexity | Notes |
| :--- | :--- | :--- |
| **Insert at beginning** | $O(1)$ | Rewire new node's next to head; update head |
| **Insert at end** | $O(n)$ | Must traverse to the last node |
| **Insert at position** | $O(n)$ | Traverse to position $- 1$ |
| **Delete from beginning** | $O(1)$ | Advance head to head.next |
| **Delete from end** | $O(n)$ | Must traverse to second-to-last node |
| **Delete at position** | $O(n)$ | Traverse to position $- 1$ |
| **Search** | $O(n)$ | Linear scan |
| **Update at position** | $O(n)$ | Traverse to position |
| **Traverse** | $O(n)$ | Visit each node once |

#### Doubly Linked List (DLL — with Head & Tail)
| Operation | Time Complexity | Notes |
| :--- | :--- | :--- |
| **Insert at beginning** | $O(1)$ | Rewire head and new node's prev/next |
| **Insert at end** | $O(1)$ | Rewire tail directly using tail pointer |
| **Insert at position** | $O(n)$ | Traverse to position |
| **Delete from beginning** | $O(1)$ | Advance head; set head.prev to null |
| **Delete from end** | $O(1)$ | Rewire tail directly using tail pointer |
| **Delete at position** | $O(n)$ | Traverse to position; rewire adjacent node pointers |
| **Search** | $O(n)$ | Linear scan |
| **Update at position** | $O(n)$ | Traverse to position |
| **Traverse Forward** | $O(n)$ | Head $	o$ Tail |
| **Traverse Backward** | $O(n)$ | Tail $	o$ Head |

#### Circular Linked List (CLL — Circular Singly)
| Operation | Time Complexity | Notes |
| :--- | :--- | :--- |
| **Insert at beginning** | $O(n)$ | Must find last node so its next points to new head |
| **Insert at end** | $O(n)$ | Must find last node so its next points to new node |
| **Delete from beginning** | $O(n)$ | Must find last node and update its next pointer |
| **Delete from end** | $O(n)$ | Must find second-to-last node |
| **Search** | $O(n)$ | Scans with loop-break check (`curr != head`) |
| **Traverse** | $O(n)$ | Stops when loop wraps back to head |

---

### 7. Comprehensive Linked List Comparison: SLL vs. DLL vs. CLL

| Feature | Singly Linked List (SLL) | Doubly Linked List (DLL) | Circular Linked List (CLL) |
| :--- | :--- | :--- | :--- |
| **Pointers per node** | 1 (`Next`) | 2 (`Prev`, `Next`) | 1 (`Next`) |
| **Traversal Direction** | Forward only | Bidirectional (Forward & Backward) | Forward (loops indefinitely) |
| **Last node's `Next`** | `null` | `null` | Points back to `Head` |
| **Head's `Prev`** | N/A | `null` | N/A |
| **Memory per node** | Low (data + 1 pointer) | High (data + 2 pointers) | Low (data + 1 pointer) |
| **Insert at beginning** | $O(1)$ | $O(1)$ | $O(n)$ |
| **Insert at end** | $O(n)$ | $O(1)$ (with tail pointer) | $O(n)$ |
| **Delete from beginning**| $O(1)$ | $O(1)$ | $O(n)$ |
| **Delete from end** | $O(n)$ | $O(1)$ (with tail pointer) | $O(n)$ |
| **Access by index** | $O(n)$ | $O(n)$ | $O(n)$ |
| **Infinite loop risk** | None | None | High (requires cycle check) |
| **Real-World Uses** | Playlists, Undo stacks, Hash chaining | Browser Back/Forward, LRU Cache, Text editors | Round-Robin CPU scheduling, Ring buffers |

---

### Verification & Commit Note
All code files adhere strictly to the lab specifications, utilizing locked versions of `Swashbuckle.AspNetCore` (v9.0.6) and `Microsoft.OpenApi` (v1.6.25). Tested and verified under .NET 9.0 with 0 build errors and 0 build warnings.
