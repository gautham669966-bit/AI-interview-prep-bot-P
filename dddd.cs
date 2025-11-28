#include <iostream>
#include <vector>
#include <string>
#include <map>
#include <queue>
#include <stack>
#include <algorithm>
#include <random>
#include <fstream>

using namespace std;

// Simple Question Structure
struct Question {
    int id;
    string title;
    string description;
    string difficulty; // Easy, Medium, Hard
    string category;   // Array, String, etc.
    string hint;
    string solution;
    
    Question() = default;
    Question(int _id, string _title, string _desc, string _diff, string _cat, string _hint, string _sol) 
        : id(_id), title(_title), description(_desc), difficulty(_diff), category(_cat), hint(_hint), solution(_sol) {}
};

// Simple User Progress
struct UserProgress {
    int totalQuestions;
    int solvedQuestions;
    int currentStreak;
    map<string, int> categoryCount; // How many solved in each category
    
    UserProgress() : totalQuestions(0), solvedQuestions(0), currentStreak(0) {}
};

// Simple AI Interview Prep Bot
class SimpleAIBot {
private:
    vector<Question> questions;
    UserProgress progress;
    
public:
    SimpleAIBot() {
        loadQuestions();
        progress.totalQuestions = questions.size();
    }
    
    void loadQuestions() {
        // Basic Array Questions
        questions.push_back(Question(1, "Find Maximum in Array", 
            "Find the largest number in an array of integers.",
            "Easy", "Array", 
            "Use a simple loop to compare each element with current maximum.",
            "Keep track of max value while iterating through array."));
            
        questions.push_back(Question(2, "Find Minimum in Array", 
            "Find the smallest number in an array of integers.",
            "Easy", "Array", 
            "Similar to finding maximum, but compare for minimum value.",
            "Initialize min with first element, then compare with rest."));
            
        questions.push_back(Question(3, "Sum of Array Elements", 
            "Calculate the sum of all elements in an array.",
            "Easy", "Array", 
            "Use a loop to add each element to a sum variable.",
            "Initialize sum = 0, then add each array element to sum."));
            
        questions.push_back(Question(4, "Count Even Numbers", 
            "Count how many even numbers are in an array.",
            "Easy", "Array", 
            "Use modulo operator (%) to check if number is even.",
            "Loop through array, if num % 2 == 0, increment counter."));
            
        questions.push_back(Question(5, "Reverse Array", 
            "Reverse the order of elements in an array.",
            "Easy", "Array", 
            "Use two pointers from start and end, swap elements.",
            "Swap elements at positions i and n-1-i for i from 0 to n/2."));
            
        // Basic String Questions
        questions.push_back(Question(6, "Count Vowels", 
            "Count the number of vowels in a string.",
            "Easy", "String", 
            "Check each character if it's a vowel (a,e,i,o,u).",
            "Loop through string, check if each char is in 'aeiouAEIOU'."));
            
        questions.push_back(Question(7, "Reverse String", 
            "Reverse a string using simple method.",
            "Easy", "String", 
            "Use two pointers or built-in reverse function.",
            "Swap characters from start and end moving towards center."));
            
        questions.push_back(Question(8, "Check Palindrome", 
            "Check if a string reads the same forwards and backwards.",
            "Easy", "String", 
            "Compare string with its reverse.",
            "Compare characters from both ends moving towards center."));
            
        // Basic Search Questions
        questions.push_back(Question(9, "Linear Search", 
            "Find if an element exists in an array using linear search.",
            "Easy", "Search", 
            "Check each element one by one until you find the target.",
            "Loop through array, return index if element found, -1 if not."));
            
        questions.push_back(Question(10, "Binary Search", 
            "Find an element in a sorted array using binary search.",
            "Medium", "Search", 
            "Compare with middle element and eliminate half of the array.",
            "Compare target with middle, go left if smaller, right if larger."));
            
        // Basic Sorting Questions
        questions.push_back(Question(11, "Bubble Sort", 
            "Sort an array using bubble sort algorithm.",
            "Medium", "Sorting", 
            "Compare adjacent elements and swap if they're in wrong order.",
            "Repeatedly pass through array, swapping adjacent wrong pairs."));
            
        questions.push_back(Question(12, "Selection Sort", 
            "Sort an array using selection sort algorithm.",
            "Medium", "Sorting", 
            "Find minimum element and place it at the beginning.",
            "Find min element, swap with first, repeat for remaining array."));
            
        // Basic Stack Questions
        questions.push_back(Question(13, "Balanced Parentheses", 
            "Check if parentheses in a string are balanced.",
            "Medium", "Stack", 
            "Use stack to keep track of opening brackets.",
            "Push opening brackets, pop for closing, check if stack is empty."));
            
        // Basic Queue Questions
        questions.push_back(Question(14, "Implement Queue using Array", 
            "Implement a simple queue using array.",
            "Medium", "Queue", 
            "Use front and rear pointers to track queue positions.",
            "Maintain front and rear indices, enqueue at rear, dequeue from front."));
            
        // More Sorting Questions
        questions.push_back(Question(15, "Insertion Sort", 
            "Sort an array using insertion sort algorithm.",
            "Medium", "Sorting", 
            "Insert each element into its correct position in sorted portion.",
            "Take each element and insert it in correct position in sorted part."));
            
        questions.push_back(Question(16, "Merge Sort", 
            "Sort an array using merge sort algorithm.",
            "Medium", "Sorting", 
            "Divide array into halves, sort each half, then merge.",
            "Recursively divide array, then merge sorted halves."));
            
        questions.push_back(Question(17, "Quick Sort", 
            "Sort an array using quick sort algorithm.",
            "Medium", "Sorting", 
            "Choose pivot, partition array, recursively sort partitions.",
            "Pick pivot, partition around it, recursively sort both parts."));
            
        // Tree Questions
        questions.push_back(Question(18, "Binary Tree Traversal", 
            "Traverse a binary tree in inorder, preorder, postorder.",
            "Medium", "Tree", 
            "Use recursion to visit nodes in different orders.",
            "Inorder: left-root-right, Preorder: root-left-right, Postorder: left-right-root."));
            
        questions.push_back(Question(19, "Find Maximum in Binary Tree", 
            "Find the maximum value in a binary tree.",
            "Easy", "Tree", 
            "Use recursion to compare values in left and right subtrees.",
            "Recursively find max in left and right subtrees, compare with root."));
            
        questions.push_back(Question(20, "Binary Search Tree Insert", 
            "Insert a node into a binary search tree.",
            "Medium", "Tree", 
            "Compare with root, go left if smaller, right if larger.",
            "If value < root, go left; if value > root, go right; insert at null."));
            
        questions.push_back(Question(21, "Check if Binary Tree is BST", 
            "Check if a binary tree is a valid binary search tree.",
            "Medium", "Tree", 
            "Use inorder traversal or check min/max constraints.",
            "Inorder traversal of BST should give sorted sequence."));
            
        // Graph Questions
        questions.push_back(Question(22, "Graph Representation", 
            "Represent a graph using adjacency list or matrix.",
            "Easy", "Graph", 
            "Use array of lists for adjacency list, 2D array for matrix.",
            "Adjacency list: vector<vector<int>>, Matrix: int[n][n]."));
            
        questions.push_back(Question(23, "BFS Traversal", 
            "Implement breadth-first search traversal of a graph.",
            "Medium", "Graph", 
            "Use queue to visit nodes level by level.",
            "Use queue: add start node, visit neighbors, mark visited."));
            
        questions.push_back(Question(24, "DFS Traversal", 
            "Implement depth-first search traversal of a graph.",
            "Medium", "Graph", 
            "Use stack or recursion to visit nodes depth-wise.",
            "Use stack/recursion: visit node, mark visited, visit neighbors."));
            
        questions.push_back(Question(25, "Find Path in Graph", 
            "Find if a path exists between two nodes in a graph.",
            "Medium", "Graph", 
            "Use BFS or DFS to search for target node.",
            "Start BFS/DFS from source, check if we reach target."));
            
        // More Queue Questions
        questions.push_back(Question(26, "Implement Queue using Stacks", 
            "Implement a queue using two stacks.",
            "Medium", "Queue", 
            "Use one stack for enqueue, another for dequeue operations.",
            "Use stack1 for enqueue, stack2 for dequeue, transfer when needed."));
            
        questions.push_back(Question(27, "Circular Queue", 
            "Implement a circular queue using array.",
            "Medium", "Queue", 
            "Use modulo operation to wrap around the array.",
            "Use (rear + 1) % size for circular increment."));
            
        questions.push_back(Question(28, "Queue using Linked List", 
            "Implement a queue using linked list.",
            "Medium", "Queue", 
            "Use front and rear pointers to linked list nodes.",
            "Enqueue at rear, dequeue from front, update pointers."));
            
        // Linked List Questions
        questions.push_back(Question(29, "Insert Node in Linked List", 
            "Insert a node at the beginning, middle, or end of linked list.",
            "Easy", "LinkedList", 
            "Create new node, adjust pointers accordingly.",
            "At beginning: new->next = head; head = new. At end: traverse and link."));
            
        questions.push_back(Question(30, "Delete Node from Linked List", 
            "Delete a node from linked list given its value.",
            "Easy", "LinkedList", 
            "Find the node, adjust previous node's next pointer.",
            "Find node, set prev->next = node->next, delete node."));
            
        questions.push_back(Question(31, "Reverse Linked List", 
            "Reverse a singly linked list.",
            "Medium", "LinkedList", 
            "Use three pointers: prev, current, next.",
            "Iterate: save next, reverse link, move pointers forward."));
            
        questions.push_back(Question(32, "Find Middle of Linked List", 
            "Find the middle node of a linked list.",
            "Easy", "LinkedList", 
            "Use slow and fast pointers (tortoise and hare).",
            "Slow moves 1 step, fast moves 2 steps. When fast reaches end, slow is at middle."));
            
        questions.push_back(Question(33, "Detect Cycle in Linked List", 
            "Check if a linked list has a cycle.",
            "Medium", "LinkedList", 
            "Use Floyd's algorithm with slow and fast pointers.",
            "If fast and slow pointers meet, there's a cycle."));
            
        questions.push_back(Question(34, "Merge Two Sorted Linked Lists", 
            "Merge two sorted linked lists into one sorted list.",
            "Medium", "LinkedList", 
            "Compare heads, take smaller, advance that pointer.",
            "Use dummy node, compare values, link smaller node, advance."));
            
        // Basic Math Questions
        questions.push_back(Question(35, "Fibonacci Numbers", 
            "Generate first n Fibonacci numbers.",
            "Easy", "Math", 
            "Each number is sum of previous two numbers.",
            "Start with 0,1 then each next number is sum of previous two."));
            
        questions.push_back(Question(36, "Prime Number Check", 
            "Check if a given number is prime.",
            "Easy", "Math", 
            "Check if number has any divisors from 2 to sqrt(n).",
            "Loop from 2 to sqrt(n), if any number divides n, it's not prime."));
            
        questions.push_back(Question(37, "GCD of Two Numbers", 
            "Find Greatest Common Divisor of two numbers.",
            "Easy", "Math", 
            "Use Euclidean algorithm: gcd(a,b) = gcd(b, a%b).",
            "Keep dividing larger by smaller until remainder is 0."));
            
        // Additional Array Questions
        questions.push_back(Question(38, "Two Sum Problem", 
            "Find two numbers in array that add up to target.",
            "Easy", "Array", 
            "Use nested loops or hash map for O(n) solution.",
            "For each element, check if (target - element) exists in array."));
            
        questions.push_back(Question(39, "Remove Duplicates", 
            "Remove duplicate elements from sorted array.",
            "Easy", "Array", 
            "Use two pointers to track unique elements.",
            "Keep one pointer for unique position, another for traversal."));
            
        // Additional String Questions
        questions.push_back(Question(40, "Anagram Check", 
            "Check if two strings are anagrams of each other.",
            "Easy", "String", 
            "Sort both strings and compare, or count character frequency.",
            "Two strings are anagrams if they have same character frequencies."));
            
        questions.push_back(Question(41, "Longest Common Substring", 
            "Find the longest common substring between two strings.",
            "Medium", "String", 
            "Use dynamic programming or sliding window approach.",
            "Build a 2D table to track matching characters."));
            
        // Additional Stack Questions
        questions.push_back(Question(42, "Valid Parentheses", 
            "Check if string has valid parentheses (), [], {}.",
            "Easy", "Stack", 
            "Use stack to match opening and closing brackets.",
            "Push opening brackets, for closing brackets check if stack top matches."));
            
        questions.push_back(Question(43, "Next Greater Element", 
            "Find next greater element for each element in array.",
            "Medium", "Stack", 
            "Use stack to keep track of elements waiting for next greater.",
            "Push elements to stack, pop when we find a greater element."));
    }
    
    void displayWelcome() {
        cout << "\n" << string(60, '=') << endl;
        cout << "SIMPLE AI INTERVIEW PREP BOT - EXPANDED EDITION" << endl;
        cout << string(60, '=') << endl;
        cout << "Welcome! Let's practice DSA concepts!" << endl;
        cout << "Topics: Arrays, Strings, Sorting, Trees, Graphs, Queues, LinkedLists & More!" << endl;
        cout << "Questions available: " << questions.size() << endl;
        cout << "Your progress: " << progress.solvedQuestions << "/" << progress.totalQuestions << endl;
        cout << string(60, '=') << endl;
    }
    
    void displayMenu() {
        cout << "\nWhat would you like to do?" << endl;
        cout << "1. Practice Random Question" << endl;
        cout << "2. Practice by Difficulty (Easy/Medium)" << endl;
        cout << "3. Practice by Category" << endl;
        cout << "4. View My Progress" << endl;
        cout << "5. Get Study Tips" << endl;
        cout << "6. Quick Quiz (3 questions)" << endl;
        cout << "7. Save Progress" << endl;
        cout << "8. Exit" << endl;
        cout << "\nEnter your choice (1-8): ";
    }
    
    void practiceRandomQuestion() {
        if (questions.empty()) {
            cout << "No questions available!" << endl;
            return;
        }
        
        // Simple random selection
        int randomIndex = rand() % questions.size();
        Question q = questions[randomIndex];
        
        displayQuestion(q);
        handleQuestionActions(q);
    }
    
    void practiceByDifficulty() {
        cout << "\nChoose difficulty:" << endl;
        cout << "1. Easy" << endl;
        cout << "2. Medium" << endl;
        cout << "Enter choice (1-2): ";
        
        int choice;
        cin >> choice;
        
        string difficulty = (choice == 1) ? "Easy" : "Medium";
        
        // Simple filtering
        vector<Question> filtered;
        for (const Question& q : questions) {
            if (q.difficulty == difficulty) {
                filtered.push_back(q);
            }
        }
        
        if (filtered.empty()) {
            cout << "No questions found for difficulty: " << difficulty << endl;
            return;
        }
        
        cout << "\n" << difficulty << " questions available:" << endl;
        for (size_t i = 0; i < filtered.size(); i++) {
            cout << i + 1 << ". " << filtered[i].title << endl;
        }
        
        cout << "Choose question (1-" << filtered.size() << "): ";
        int selection;
        cin >> selection;
        
        if (selection >= 1 && selection <= filtered.size()) {
            displayQuestion(filtered[selection - 1]);
            handleQuestionActions(filtered[selection - 1]);
        }
    }
    
    void practiceByCategory() {
        cout << "\nChoose category:" << endl;
        cout << "1. Array" << endl;
        cout << "2. String" << endl;
        cout << "3. Search" << endl;
        cout << "4. Sorting" << endl;
        cout << "5. Stack" << endl;
        cout << "6. Queue" << endl;
        cout << "7. Tree" << endl;
        cout << "8. Graph" << endl;
        cout << "9. LinkedList" << endl;
        cout << "10. Math" << endl;
        cout << "Enter choice (1-10): ";
        
        int choice;
        cin >> choice;
        
        vector<string> categories = {"Array", "String", "Search", "Sorting", "Stack", "Queue", "Tree", "Graph", "LinkedList", "Math"};
        
        if (choice < 1 || choice > 10) {
            cout << "Invalid choice!" << endl;
            return;
        }
        
        string selectedCategory = categories[choice - 1];
        
        // Simple filtering by category
        vector<Question> filtered;
        for (const Question& q : questions) {
            if (q.category == selectedCategory) {
                filtered.push_back(q);
            }
        }
        
        if (filtered.empty()) {
            cout << "No questions found for category: " << selectedCategory << endl;
            return;
        }
        
        cout << "\n" << selectedCategory << " questions:" << endl;
        for (size_t i = 0; i < filtered.size(); i++) {
            cout << i + 1 << ". " << filtered[i].title << " (" << filtered[i].difficulty << ")" << endl;
        }
        
        cout << "Choose question (1-" << filtered.size() << "): ";
        int selection;
        cin >> selection;
        
        if (selection >= 1 && selection <= filtered.size()) {
            displayQuestion(filtered[selection - 1]);
            handleQuestionActions(filtered[selection - 1]);
        }
    }
    
    void displayQuestion(const Question& q) {
        cout << "\n" << string(40, '-') << endl;
        cout << "QUESTION #" << q.id << endl;
        cout << string(40, '-') << endl;
        cout << "Title: " << q.title << endl;
        cout << "Difficulty: " << q.difficulty << endl;
        cout << "Category: " << q.category << endl;
        cout << "Description: " << q.description << endl;
        cout << string(40, '-') << endl;
    }
    
    void handleQuestionActions(const Question& q) {
        cout << "\nWhat would you like to do?" << endl;
        cout << "1. Show Hint" << endl;
        cout << "2. Show Solution" << endl;
        cout << "3. Mark as Solved" << endl;
        cout << "4. Skip" << endl;
        cout << "Enter choice (1-4): ";
        
        int choice;
        cin >> choice;
        
        switch (choice) {
            case 1:
                cout << "\nHINT: " << q.hint << endl;
                break;
            case 2:
                cout << "\nSOLUTION: " << q.solution << endl;
                break;
            case 3:
                markAsSolved(q);
                break;
            case 4:
                cout << "Question skipped!" << endl;
                break;
            default:
                cout << "Invalid choice!" << endl;
        }
    }
    
    void markAsSolved(const Question& q) {
        progress.solvedQuestions++;
        progress.currentStreak++;
        progress.categoryCount[q.category]++;
        
        cout << "\nGreat job! Question marked as solved!" << endl;
        cout << "Questions solved: " << progress.solvedQuestions << "/" << progress.totalQuestions << endl;
        cout << "Current streak: " << progress.currentStreak << endl;
        
        // Simple encouragement
        if (progress.solvedQuestions == 1) {
            cout << "You've solved your first question! Keep going!" << endl;
        } else if (progress.solvedQuestions == 5) {
            cout << "Awesome! You've solved 5 questions!" << endl;
        } else if (progress.solvedQuestions == 10) {
            cout << "Excellent! You're making great progress!" << endl;
        }
    }
    
    void viewProgress() {
        cout << "\nYOUR PROGRESS" << endl;
        cout << string(30, '=') << endl;
        cout << "Total Questions: " << progress.totalQuestions << endl;
        cout << "Solved Questions: " << progress.solvedQuestions << endl;
        cout << "Current Streak: " << progress.currentStreak << endl;
        
        // Calculate percentage
        double percentage = (double)progress.solvedQuestions / progress.totalQuestions * 100;
        cout << "Progress: " << int(percentage) << "%" << endl;
        
        cout << "\nCategory Progress:" << endl;
        for (const auto& pair : progress.categoryCount) {
            cout << "• " << pair.first << ": " << pair.second << " questions" << endl;
        }
        
        // Simple progress bar
        cout << "\nProgress Bar: [";
        int filled = (int)(percentage / 10);
        for (int i = 0; i < 10; i++) {
            if (i < filled) {
                cout << "█";
            } else {
                cout << "░";
            }
        }
        cout << "] " << int(percentage) << "%" << endl;
    }
    
    void showStudyTips() {
        vector<string> tips = {
            "Start with Easy questions to build confidence",
            "Practice one category at a time (like Arrays first)",
            "Always try to solve before looking at hints",
            "Set a daily goal (like 1 question per day)",
            "Review your solved questions weekly",
            "Don't give up if you can't solve immediately",
            "Write down the logic before coding",
            "Test your solution with different inputs"
        };
        
        cout << "\nSTUDY TIPS" << endl;
        cout << string(20, '=') << endl;
        
        // Show random tips
        random_shuffle(tips.begin(), tips.end());
        for (int i = 0; i < min(5, (int)tips.size()); i++) {
            cout << tips[i] << endl;
        }
    }
    
    void quickQuiz() {
        cout << "\nQUICK QUIZ - 3 Questions" << endl;
        cout << "Let's test your knowledge!" << endl;
        cout << "Press Enter to start...";
        cin.ignore();
        cin.get();
        
        int score = 0;
        
        // Simple quiz with 3 random questions
        for (int i = 0; i < 3; i++) {
            cout << "\n--- Question " << i + 1 << " of 3 ---" << endl;
            
            int randomIndex = rand() % questions.size();
            Question q = questions[randomIndex];
            
            displayQuestion(q);
            
            cout << "Do you know how to solve this? (y/n): ";
            char answer;
            cin >> answer;
            
            if (answer == 'y' || answer == 'Y') {
                score++;
                cout << "Correct confidence!" << endl;
            } else {
                cout << "Hint: " << q.hint << endl;
            }
        }
        
        cout << "\nQuiz Complete!" << endl;
        cout << "Your confidence score: " << score << "/3" << endl;
        
        if (score == 3) {
            cout << "Excellent! You're well prepared!" << endl;
        } else if (score == 2) {
            cout << "Good job! Keep practicing!" << endl;
        } else {
            cout << "Keep studying! You'll get better!" << endl;
        }
    }
    
    void saveProgress() {
        ofstream file("my_progress.txt");
        if (file.is_open()) {
            file << "=== My DSA Progress ===" << endl;
            file << "Total Questions: " << progress.totalQuestions << endl;
            file << "Solved Questions: " << progress.solvedQuestions << endl;
            file << "Current Streak: " << progress.currentStreak << endl;
            file << "Progress: " << int((double)progress.solvedQuestions / progress.totalQuestions * 100) << "%" << endl;
            
            file << "\nCategory Progress:" << endl;
            for (const auto& pair : progress.categoryCount) {
                file << pair.first << ": " << pair.second << " questions" << endl;
            }
            
            file.close();
            cout << "Progress saved to 'my_progress.txt'" << endl;
        } else {
            cout << "Could not save progress" << endl;
        }
    }
    
    void run() {
        displayWelcome();
        
        while (true) {
            displayMenu();
            int choice;
            cin >> choice;
            
            switch (choice) {
                case 1:
                    practiceRandomQuestion();
                    break;
                case 2:
                    practiceByDifficulty();
                    break;
                case 3:
                    practiceByCategory();
                    break;
                case 4:
                    viewProgress();
                    break;
                case 5:
                    showStudyTips();
                    break;
                case 6:
                    quickQuiz();
                    break;
                case 7:
                    saveProgress();
                    break;
                case 8:
                    cout << "\nThanks for using Simple AI Prep Bot!" << endl;
                    cout << "Keep practicing and you'll master DSA!" << endl;
                    return;
                default:
                    cout << "Invalid choice! Please try again." << endl;
            }
        }
    }
};

int main() {
    // Simple random seed
    srand(time(0));
    
    cout << "Starting Simple AI Interview Prep Bot..." << endl;
    
    SimpleAIBot bot;
    bot.run();
    
    return 0;
}