#include <iostream>
#include <unordered_map>
#include <queue>
#include <vector>
#include <algorithm>

using namespace std;

struct Question {
    string questionText;
    vector<string> options;
    int correctOption;
};

unordered_map<string, vector<Question>> questionBank;

struct User {
    string name;
    int score;
    User* left;
    User* right;

    User(string n, int s) : name(n), score(s), left(nullptr), right(nullptr) {}
};

User* insertUser(User* root, string name, int score) {
    if (!root) return new User(name, score);
    if (score <= root->score)
        root->left = insertUser(root->left, name, score);
    else
        root->right = insertUser(root->right, name, score);
    return root;
}

void inorderDisplay(User* root) {
    if (!root) return;
    inorderDisplay(root->right);
    cout << root->name << " - Score: " << root->score << endl;
    inorderDisplay(root->left);
}

void addSampleQuestions() {
    questionBank["DSA"] = {
        {"What is the time complexity of binary search?", {"O(n)", "O(log n)", "O(n log n)", "O(1)"}, 2},
        {"Which data structure uses FIFO?", {"Stack", "Queue", "Tree", "Graph"}, 2}
    };
    questionBank["OOP"] = {
        {"Which is not a principle of OOP?", {"Inheritance", "Encapsulation", "Recursion", "Polymorphism"}, 3}
    };
}

int main() {
    addSampleQuestions();

    string topic;
    cout << "Enter your name: ";
    string userName;
    getline(cin, userName);

    cout << "Choose topic (DSA/OOP): ";
    cin >> topic;

    if (questionBank.find(topic) == questionBank.end()) {
        cout << "No questions for this topic.\n";
        return 0;
    }

    queue<Question> q;
    for (auto& que : questionBank[topic]) q.push(que);

    int score = 0, i = 1;
    while (!q.empty()) {
        auto qn = q.front(); q.pop();
        cout << "\nQ" << i++ << ": " << qn.questionText << endl;
        for (int j = 0; j < qn.options.size(); ++j)
            cout << j + 1 << ". " << qn.options[j] << endl;

        int userAns;
        cout << "Your answer: ";
        cin >> userAns;

        if (userAns == qn.correctOption)
            score += 10;
    }

    cout << "\n" << userName << ", your final score is: " << score << endl;

    static User* root = nullptr;
    root = insertUser(root, userName, score);

    cout << "\n=== Leaderboard ===\n";
    inorderDisplay(root);

    return 0;
}