# ASSIGNAMENT 5

## First Aproach
My initial goal was to develop a fine-tuned license plate recognition system for `Harinera LaMeta`. This would have allowed us to avoid relying on Hikvision cameras and to improve performance in scenarios where they fail.

This approach turned out to be a dead end. Although it initially seemed viable, the complexity increased dramatically during the image-loading stage. Managing the data pipeline alone became impractical.

The abandoned approach is documented in `historico-transito-vehiculos.ipynb`. That notebook includes a method to download roughly 30 GB of correctly labeled license-plate images, split into training and test datasets.

## Second Aproach
