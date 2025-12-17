import torch
import torch.nn as nn
import torch.nn.functional as F

if torch.backends.mps.is_available():
    device=torch.device("mps")
else:
    device = torch.device("cuda:0" if torch.cuda.is_available() else "cpu")


class QNet(nn.Module):
    """Actor (Policy) Network Model."""

    def __init__(self, state_size, action_size, seed=42, fc1_units=64, fc2_units=64):
        """
        Initialize parameters and build model.
        
        :param state_size: (int) # state
        :param action_size: (int) # action
        :param seed: (int) Random 
        :param fc1_units: (int) First hidden layer size
        :param fc2_units: (int) Second hidden layer size
        """
        super(QNet, self).__init__()
        self.seed = torch.manual_seed(seed)
        self.fc1 = nn.Linear(state_size, fc1_units)
        self.fc2 = nn.Linear(fc1_units, fc2_units)
        self.fc3 = nn.Linear(fc2_units, action_size)

    def forward(self, state):
        """Build a network that maps state -> action values."""
        x = F.relu(self.fc1(state))
        x = F.relu(self.fc2(x))
        return self.fc3(x)
