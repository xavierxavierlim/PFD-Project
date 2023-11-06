const reminders = [
"Reminder: Keep a lookout of your surroundings",
"Reminder: Ensure that nobody is near you before keying in your pin",
"Reminder: Do not forget to take your card",
"Reminder: Report any suspicious activity",
"Reminder: Do not share your pin with anyone"
];

shuffleArray(reminders);

let currentReminderIndex = 0;

function updateReminder() {
    document.getElementById('reminderText').textContent = reminders[currentReminderIndex];
currentReminderIndex = (currentReminderIndex + 1) % reminders.length;

setTimeout(updateReminder, 30000); // Change the reminder every 30 seconds
    }

function shuffleArray(array) {
        for (let i = array.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
[array[i], array[j]] = [array[j], array[i]];
        }
    }

// Start the reminder loop
updateReminder();
