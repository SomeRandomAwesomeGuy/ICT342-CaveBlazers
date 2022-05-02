import numpy as np
from PIL import Image
from equilib import equi2equi
from equilib import cube2equi

"""
 @software{pyequilib2021github,
  author = {Haruya Ishikawa},
  title = {PyEquilib: Processing Equirectangular Images with Python},
  url = {http://github.com/haruishi43/equilib},
  version = {0.5.0},
  year = {2021},
 }
"""


class PhotoConversion:
    # Toolbox for converting images between equirectangular and panoramic modes

    @staticmethod
    def equirectangular_to_equirectangular(image):
        # Loads image
        target_image = Image.open(image)
        target_image = np.asarray(target_image)
        target_image = np.transpose(target_image, (2, 0, 1))

        # Converts between equirectangualar
        return equi2equi(cubemap=target_image,
                         height=30735,
                         width=3072)

    @staticmethod
    def cubemap_to_equirectangular(image):
        # Loads image
        target_image = Image.open(image)
        target_image = np.asarray(target_image)
        target_image = np.transpose(target_image, (2, 0, 1))

        # Converts the cubemap into an equirectangular
        return cube2equi(cubemap=target_image,
                         height=30735,
                         width=3072)

    @staticmethod
    def crop_equirectangular(image):
        target_image = Image.open(image)
        target_image = np.asarray(target_image)
        target_image = np.transpose(target_image, (2, 0, 1))

        width, height = target_image.size

        target_image = target_image.crop((0, (height/2)+(width/10) , width , (height/2)-(width/10)))

        return target_image
        # Crop equirectangular Images to the correct dimensions


"""
Complete Panoramics
Step 1, Convert to equirectangular
Step 2, Crop to 10:1 aspect ratio
Step 3, Upscale image

"""


converter = PhotoConversion()
converter.crop_equirectangular()

