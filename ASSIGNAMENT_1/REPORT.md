# REPORT

| DAMPING FACTOR | ITERATIONS | TOP 1 NAME  | TOP 1 VALUE           |
|----------------|------------|-------------|-----------------------|
| 0.70           | 10         | NEWMAN, M   | 0.0027993366853601544 |
| 0.70           | 20         | NEWMAN, M   | 0.002798206926988279  |
| 0.70           | 30         | NEWMAN, M   | 0.002798187807474738  |
| 0.70           | 40         | NEWMAN, M   | 0.0027981874792519816 |
| 0.85           | 10         | NEWMAN, M   | 0.0031605108233803306 |
| 0.85           | 20         | NEWMAN, M   | 0.0031455940476091296 |
| 0.85           | 30         | NEWMAN, M   | 0.0031438308818457286 |
| 0.85           | 40         | NEWMAN, M   | 0.003143619694635288  |
| 1.00           | 10         | BARABASI, A | 0.003427646324286501  |
| 1.00           | 20         | BARABASI, A | 0.0034883933513935603 |
| 1.00           | 30         | BARABASI, A | 0.003543857546059132  |
| 1.00           | 40         | BARABASI, A | 0.0035804971317599803 |

```mermaid
graph TD
    subgraph Damping_0_70["Damping Factor 0.70"]
        A1["Iter 10: NEWMAN, M (0.0027993)"]
        A2["Iter 20: NEWMAN, M (0.0027982)"]
        A3["Iter 30: NEWMAN, M (0.0027981)"]
        A4["Iter 40: NEWMAN, M (0.0027981)"]
        A1 --> A2 --> A3 --> A4
    end

    subgraph Damping_0_85["Damping Factor 0.85"]
        B1["Iter 10: NEWMAN, M (0.0031605)"]
        B2["Iter 20: NEWMAN, M (0.0031455)"]
        B3["Iter 30: NEWMAN, M (0.0031438)"]
        B4["Iter 40: NEWMAN, M (0.0031436)"]
        B1 --> B2 --> B3 --> B4
    end

    subgraph Damping_1_00["Damping Factor 1.00"]
        C1["Iter 10: BARABASI, A (0.0034276)"]
        C2["Iter 20: BARABASI, A (0.0034883)"]
        C3["Iter 30: BARABASI, A (0.0035438)"]
        C4["Iter 40: BARABASI, A (0.0035804)"]
        C1 --> C2 --> C3 --> C4
    end

    Damping_0_70 --> Damping_0_85 --> Damping_1_00
```

![Top 1 Value Plot](top1_value_plot.png)
