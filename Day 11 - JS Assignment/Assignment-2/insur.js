function updateStatus(id, message) {
    const status = document.getElementById(id);
    if (status) {
        status.textContent = message;
        status.className = 'status status-success';
    }
}


function setupEvents() {
    document.getElementById('payPremium').addEventListener('click', function(e) {
        console.log('EX1: Button clicked first');
        updateStatus('ex1-status', 'Button → Div (Bubbling)');
        
        setTimeout(() => {
            console.log('EX1: Div clicked second (bubbling phase)');
        }, 100);
    });

    document.getElementById('paymentSection').addEventListener('click', function(e) {
        console.log('EX1: Div clicked directly');
    });

    document.getElementById('policyContainer').addEventListener('click', function(e) {
        console.log('EX2: Parent first (capturing phase)');
        console.log('Event phase:', e.eventPhase);
        updateStatus('ex2-status', 'Parent → Child (Capturing)');
    }, true);

    document.getElementById('showPolicy').addEventListener('click', function(e) {
        console.log('EX2: Child second');
    }, true);

    document.getElementById('policyCard').addEventListener('click', function(e) {
        console.log('EX3: Navigate to details (blocked)');
    });

    document.getElementById('deleteBtn').addEventListener('click', function(e) {
        e.stopPropagation();
        console.log('EX3: Delete only');
        updateStatus('ex3-status', 'Delete only (stopPropagation)');
    });

    document.getElementById('claimRow').addEventListener('click', function(e) {
        console.log('EX4: Open claim details (blocked)');
    });

    document.getElementById('approveClaim').addEventListener('click', function(e) {
        e.stopPropagation();
        console.log('EX4: Claim approved only');
        updateStatus('ex4-status', 'Approve only');
    });
}

if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', setupEvents);
} else {
    setupEvents();
}
