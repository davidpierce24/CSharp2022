// Queue - First in first out

class Node {
    constructor(val) {
        this.data = val;
        this.next = null;
    }
}

class Queue {
    constructor() {
        this.top = null;
        this.tail = null;
        // keep track of the length
        this.length = 0;
    }

    print() {
        var arr = [];
        var runner = this.top;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        console.log(arr);
    }

    // Enqueue - add an item and return the new size of the queue
    enqueue(val) {
        let node = new Node(val);
        if (this.isEmpty()) {
            this.top = node;
            this.tail = node;
            this.length++;
            return this.length;
        } else {
            this.tail.next = node;
            this.tail = this.tail.next;
            this.length++;
            return this.length;
        }
    }

    // Dequeue - remove and return the first item
    dequeue() {
        if (this.isEmpty()) {
            return "the queue is empty";
        } else {
            let temp = this.top;
            this.top = this.top.next;
            return temp;
        }
    }

    // IsEmpty - return true or false whether the queue is empty
    isEmpty() {
        return this.top == null;
    }

    // Front - return the first item without removing it
    front() {
        if (this.isEmpty()) {
            return "Queue is empty"
        } else {
            console.log(`the front is ${this.top.data}`)
            return this.top.data;
        }
    }

    // Compare queues using the built in methods you have written so far for Queues
    compare(otherQ) {
        if(this.length != otherQ.length){
            return false;
        } else {
            let runner1 = this.top;
            let runner2 = otherQ.top;
            while(runner1){
                if(runner1.data != runner2.data){
                    return false;
                }
                runner1 = runner1.next;
                runner2 = runner2.next;
            }
        return true;
        }
    }

    // Return true or false whether a queue is a palindrome, also using only built in methods
    isPalindrome() {
        let temp = new Queue();
        let runner1 = this.top;
        while(runner1){
            temp.enqueue(runner1.data);
            runner1 = runner1.next;
        }
        temp.print();
        let q2 = new Queue();
        let runner = temp.top;
        while(runner){
            q2.enqueue(temp.dequeue().data);
            // q2.enqueue(temp.front());
            // temp.dequeue();
            runner = runner.next;
        }
        this.print()
        q2.print()
        return this.compare(q2);
    }

    // Return true or false whether the sum of the front half of your queue is equal to the sum of the left half of your queue - as before, try to limit yourself to only built in methods within your queue class
    SumOfHalves() {
        if(this.isEmpty()) {
            return false;
        }
        
        let count = Math.floor(this.length/2);
        let sum1 = 0;
        let sum2 = 0;

        for(let i = 0; i < count; i++) {
            this.enqueue(this.front());
            sum1 += this.front();
            this.dequeue();
        }

        if(this.length%2 != 0) {
            this.enqueue(this.front());
            this.dequeue();
        }

        for(let j = 0; j < count; j++) {
            this.enqueue(this.front());
            sum2 += this.front();
            this.dequeue();
        }

        return sum1 == sum2;
    }
}

// Two Stack Queue
// This one is a proof on concept: can you get the functionality of a queue using two stacks? Use your knowledge of queues and stacks to create a class called TwoStackQueue and write the enqueue and dequeue methods

class Stack
{
    constructor()
    {
        this.top=null;
    }

    Push(value)
    {
        //Code me!
        if(!this.top)
        {
            this.top = new Node(value);
            return this;
        }
        let temp = this.top;
        this.top = new Node(value);
        this.top.next = temp;
        return this;
    }

    Peek()
    {
        //Code me!
        return this.top.data;
    }

    Pop()
    {
        //Code me!
        if (!this.top){
            return;
        }
        let temp = this.top;
        this.top = this.top.next;
        return temp.data;
    }

    IsEmpty()
    {
        //Code me!
        if (!this.top){
            return;
        }
        return this.top == null; 
    }

    Log()
    {
        let str="";
        for(let node=this.top;node;node=node.next)
        {
            str+=node.data+"->";
        }
        console.log(str);
    }
};

class TwoStackQueue {
    constructor() {
        this.stack1 = new Stack();
        this.stack2 = new Stack();
    }

    enqueue(item) {
        this.stack1.Push(item);
        return this;
    }

    dequeue() {
        if (this.stack1.IsEmpty()){
            return this;
        }
        
        while (this.stack1.top){
            this.stack2.Push(this.stack1.Pop());
        }

        this.stack2.Log();

        let temp = this.stack2.Pop();
        while (this.stack2.top){
            this.stack1.Push(this.stack2.Pop());
        }

        this.stack1.Log();
        return this;
    }
}


let queue = new Queue();
queue.print();
queue.enqueue(1);
queue.enqueue(2);
queue.enqueue(2);
queue.enqueue(1);



// let queue2 = new Queue();
// queue2.print();
// queue2.enqueue(1);
// queue2.enqueue(2);
// queue2.enqueue(3);
// queue2.enqueue(4);
// queue2.print();

// console.log(queue.compare(queue2));
console.log(queue.isPalindrome());